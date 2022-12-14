using Microsoft.AspNetCore.WebUtilities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using VivaioInCloud.Identity.Abstraction.Services;
using VivaioInCloud.Identity.Entities.Dtos;
using VivaioInCloud.Identity.Entities.Models;
using VivaioInCloud.Identity.Entities.Requests;
using VivaioInCloud.Identity.Entities.Responses;
using VivaioInCloud.Identity.Model.Models;
using VivaioInCloud.Identity.Model.Responses;

namespace VivaioInCloud.Identity.Services.Services
{
    public class UserAuthenticationManager : IUserAuthenticationManager
    {
        private readonly ITokenClaimsService _tokenService;
        private readonly IApplicationUserService _userService;

        public UserAuthenticationManager(
            IApplicationUserService userService,
            ITokenClaimsService tokenService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var response = new LoginResponse();

            var user = await _userService.GetByEmailAsync(request.Email);

            if (user == null)
            {
                RegisterUserRequest registerUser = new RegisterUserRequest()
                {
                    Email = request.Email,
                    Password = request.Password
                };
                // Se non lo trovo, magari è uno vnuovo su ldap
                var isRegistered = await RegisterNewUser(registerUser);
                if (isRegistered)
                {
                    user = await _userService.GetByEmailAsync(request.Email);
                    if (user == null)
                    {
                        // error TODO
                    }

                    return await SignInUserAsync(response, user);
                }
                else
                {
                    return response.InvalidEmailOrPasswor();
                }
            }

            if (!user.IsActive)
            {
                return response.InvalidEmailOrPasswor();
            }


            var checkPass = await _userService.CheckPasswordAsync(user, request.Password);
            if (!checkPass)
            {
                return response.InvalidEmailOrPasswor();
            }

            var emailConfirmed = await _userService.IsEmailConfirmedAsync(user);
            if (!emailConfirmed)
            {
                return response.EmailNotConfirmed();
            }


            return await SignInUserAsync(response, user);
        }

        public async Task<LoginResponse> RefreshTokenAsync(RefreshTokenRequest request)
        {
            var response = new LoginResponse();

            var userPrincipal = _tokenService.ValidateAccessToken(request.AccessToken);
            if (userPrincipal == null)
            {
                return response.UserNotFound();
            }

            var value = GetClaimValue(userPrincipal, ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(value);
            var user = await _userService.GetByIdAsync(userId.ToString());

            if (user == null || !user.IsActive)
            {
                return response.UserNotFound();
            }

            if (user?.RefreshToken == null
                || user?.RefreshTokenExpirationDate < DateTime.UtcNow
                || user?.RefreshToken != request.RefreshToken)
            {
                var r = await _userService.InvalidateRefreshTokenAsync(user);
                return response.InvalidrefreshToken();
            }

            return await SignInUserAsync(response, user);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(string email)
        {
            var user = await _userService.GetByEmailAsync(email);

            if (user == null || !user.IsActive)
            {
                return String.Empty;
            }

            return await _userService.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<bool> ConfirmEmailAsync(ConfirmEmailRequest request)
        {
            var user = await _userService.GetByEmailAsync(request.Email);
            if (user == null || !user.IsActive)
            {
                return false;
            }

            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Code)).Trim();

            return await _userService.ConfirmEmailAsync(user, code);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string email)
        {
            var user = await _userService.GetByEmailAsync(email);

            if (user == null || !user.IsActive)
            {
                return String.Empty;
            }

            return await _userService.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<bool> ConfirmResetPasswordAsync(ResetPasswordRequest request)
        {
            var user = await _userService.GetByEmailAsync(request.Email);
            if (user == null || !user.IsActive)
            {
                return false;
            }

            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Token)).Trim();

            return await _userService.ResetPasswordAsync(user, code, request.NewPasword);
        }


        private string GetClaimValue(IPrincipal user, string claimType)
        {
            var value = ((ClaimsPrincipal)user).FindFirst(claimType)?.Value;
            return value;
        }

        private async Task<LoginResponse> SignInUserAsync(LoginResponse response, ApplicationUser user)
        {
            var userRoles = await _userService.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            //var scopes = await _applicationScopeService.ListAllAsync();

            //foreach (var scope in scopes)
            //{
            //    authClaims.Add(new Claim("scp", scope.Name));
            //}

            var authToken = _tokenService.GenerateAuthTokenAsync(authClaims);
            response.AccessToken = authToken.Token;
            response.AccessTokenExpiration = authToken.Expiration;

            var refreshToken = _tokenService.GenerateRefreshTokenAsync();
            var r = await _userService.SaveNewRefreshTokenAsync(user, refreshToken);

            response.RefreshToken = refreshToken.Token;
            response.RefreshTokenExpiration = refreshToken.Expiration;

            response.Succeeded = true;
            response.User = new User()
            {
                Email = user.Email,
                Id = user.Id,
                UserName = user.UserName,
                Roles = userRoles
            };

            return response;
        }

        public async Task<bool> RegisterNewUser(RegisterUserRequest request)
        {
            var userExists = await _userService.GetByEmailAsync(request.Email);

            if (userExists != null)
            {
                return false;
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = request.Email,
                UserName = request.Email,
                EmailConfirmed = false,
                TwoFactorEnabled = false,
                Name = request.Name,
                Surname = request.Surname
            };

            var newUser = await _userService.CreateUserAsync(user, request.Password);

            if (newUser == null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeactivateUser(string usertId)
        {
            var user = await _userService.GetByIdAsync(usertId);

            if (user == null || !user.IsActive)
            {
                return false;
            }

            user.IsActive = false;

            var result = await _userService.UpdateAsync(user);

            if (result == null)
            {
                return false;
            }

            return true;
        }
    }
}
