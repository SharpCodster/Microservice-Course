using Microsoft.Extensions.Logging;
using VivaioInCloud.Common;
using VivaioInCloud.Common.Exceptions;
using VivaioInCloud.Identity.Abstraction.Services;
using VivaioInCloud.Identity.Entities.Dtos;
using VivaioInCloud.Identity.Entities.Models;
using VivaioInCloud.Notificator.Abstraction;
using VivaioInCloud.Notificator.Models;

namespace VivaioInCloud.Identity.Services.Services
{
    public class UserRegistrationService : IUserRegistrationService
    {
        protected readonly ILogger<UserRegistrationService> _logger;
        private readonly IApplicationUserService _userService;
        private readonly INotify _notify;

        public UserRegistrationService(
            INotify notify,
            IApplicationUserService userService,
            ILogger<UserRegistrationService> logger)
        {
            _logger = logger;
            _userService = userService;
            _notify = notify;
        }

        public async Task<ApplicationUser> RegisterNewAdmin(RegisterAdminRequest request)
        {
            var userExists = await _userService.GetByEmailAsync(request.Email);

            if (userExists != null)
            {
                throw new DuplicatedItemException("User already exists");
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = request.Email,
                UserName = request.Email,
                EmailConfirmed = true,
                TwoFactorEnabled = false,
                IsActive = true,
                Name = request.Name,
                Surname = request.Surname
            };

            var newUser = await _userService.CreateUserAsync(user, SolutionConstants.Authorization.DEFAULT_PASSWORD);
            await _userService.AddToRoleAsync(newUser, SolutionConstants.Authorization.Roles.ADMIN);

            NewUserCreated userData = new NewUserCreated()
            {
                UserID = newUser.Id,
                Email = newUser.Email,
                Name = newUser.Name,
                Surname = newUser.Surname,
                SendRegistrationEmail = !newUser.EmailConfirmed,
                EmailRegistrationToken = null
            };

            await _notify.NotifyNewUserCreatedAsync(userData);

            return newUser;
        }


        public async Task<ApplicationUser> RegisterNewUser(RegisterUserRequest request)
        {
            var userExists = await _userService.GetByEmailAsync(request.Email);

            if (userExists != null)
            {
                throw new DuplicatedItemException("User already exists");
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = request.Email,
                UserName = request.Email,
                EmailConfirmed = false,
                TwoFactorEnabled = false,
                IsActive = true,
                Name = request.Name,
                Surname = request.Surname
            };

            var newUser = await _userService.CreateUserAsync(user, request.Password);
            await _userService.AddToRoleAsync(newUser, SolutionConstants.Authorization.Roles.USER);

            var token = await _userService.GenerateEmailConfirmationTokenAsync(newUser);

            NewUserCreated userData = new NewUserCreated()
            {
                UserID = newUser.Id,
                Email = newUser.Email,
                Name = newUser.Name,
                Surname = newUser.Surname,
                SendRegistrationEmail = !newUser.EmailConfirmed,
                EmailRegistrationToken = token
            };

            await _notify.NotifyNewUserCreatedAsync(userData);

            return newUser;
        }
    }
}
