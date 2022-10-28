using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using VivaioInCloud.Common.Options;
using VivaioInCloud.Identity.Abstraction.Services;
using VivaioInCloud.Identity.Model.Models;

namespace VivaioInCloud.Identity.Services.Services
{
    internal class TokenClaimService : ITokenClaimsService
    {
        private readonly AccessTokenOptions _options;
        private readonly RsaSecurityKey _rsaKey;
        private readonly SigningCredentials _signingCredentials;

        public TokenClaimService(IOptions<AccessTokenOptions> options, SigningCredentials signingCredentials, RsaSecurityKey rsaKey)
        {
            _signingCredentials = signingCredentials;
            _options = options.Value;
            _rsaKey = rsaKey;
        }

        public TokenData GenerateAuthTokenAsync(List<Claim> claims)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _options.Audience,
                Issuer = _options.Issuer,
                Subject = new ClaimsIdentity(claims.ToArray()),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddHours(_options.AccessTokenExpirationHours),
                SigningCredentials = _signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenData()
            {
                Token = tokenHandler.WriteToken(token),
                Expiration = (DateTime)tokenDescriptor.Expires
            };
        }

        public TokenData GenerateRefreshTokenAsync()
        {
            var randomNumber = new byte[256];
            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(randomNumber);

            return new TokenData()
            {
                Token = Convert.ToBase64String(randomNumber),
                Expiration = DateTime.UtcNow.AddDays(_options.RefreshTokenExpirationDays)
            };
        }

        public ClaimsPrincipal ValidateAccessToken(string accessToken)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _options.Issuer,
                ValidateAudience = true,
                ValidAudience = _options.Audience,
                ValidateLifetime = false, //Differenza rispetto a quello in program.cs,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _rsaKey,
                RequireExpirationTime = true,
                ClockSkew = TimeSpan.Zero,
                RequireSignedTokens = true
            };

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var user = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out var securityToken);
                if (securityToken is JwtSecurityToken jwtSecurityToken
                    && jwtSecurityToken.Header.Alg == SecurityAlgorithms.HmacSha256)
                {
                    return user;
                }
            }
            catch
            {
                //TODO
            }

            return null;
        }
    }
}
