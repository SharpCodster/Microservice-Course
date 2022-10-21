using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VivaioInCloud.Common.Abstraction.Contexts;
using VivaioInCloud.Common.Abstraction.Repositories;
using VivaioInCloud.Common.Services;
using VivaioInCloud.Identity.Abstraction.Services;
using VivaioInCloud.Identity.Entities.Models;
using VivaioInCloud.Identity.Model.Models;

namespace VivaioInCloud.Identity.Services.Services
{
    internal class ApplicationUserService : AuditableBaseService<ApplicationUser>, IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserService(
            UserManager<ApplicationUser> userManager,
            IRequestContextProvider requestContextProvider,
            IAsyncRepository<ApplicationUser> repository,
            IUnitOfWork unitOfWork,
            ILogger<ApplicationUserService> logger
            ) : base(requestContextProvider, repository, unitOfWork, logger)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        /////// CREATE /////////////////////////////////////////////////
        public async Task<ApplicationUser> CreateUserAsync(ApplicationUser entity, string password)
        {
            _logger.LogTrace($"ApplicationUserService.CreateUserAsync({JsonConvert.SerializeObject(entity, Formatting.None)}, ******)");
            await ValidateForCreateOrThrowAsync(entity);
            await BeforeCreateAsync(entity);
            await ApplyAuditInfoForCreateAsync(entity);

            var res = await _userManager.CreateAsync(entity, password);

            if (!res.Succeeded)
            {
                throw new Exception("Qualcosa è andato storto");
            }

            var result = await GetByEmailAsync(entity.Email);
            await AfterCreateAsync(result);
            _logger.LogTrace($"ApplicationUserService.CreateUserAsync returned: {JsonConvert.SerializeObject(result, Formatting.None)}");
            return result;
        }

        /////// UPDATE /////////////////////////////////////////////////
        protected override async Task<ApplicationUser> UpdateCoreAsync(ApplicationUser entity)
        {
            _logger.LogTrace($"ApplicationUserService.UpdateCoreAsync({JsonConvert.SerializeObject(entity, Formatting.None)})");

            await ValidateForUpdateOrThrowAsync(entity);
            await BeforeUpdateAsync(entity);
            await ApplyAuditInfoForUpdateAsync(entity);

            var updatedEntity = await _userManager.UpdateAsync(entity);

            if (!updatedEntity.Succeeded)
            {
                throw new Exception("Qualcosa è andato storto");
            }

            // Lo leggo per ricevere i nuovi campi di concurrency
            ApplicationUser result = await GetByIdAsync(entity.Id);

            await AfterUpdateAsync(result);
            _logger.LogTrace($"ApplicationUserService.UpdateCoreAsync returned: {JsonConvert.SerializeObject(entity, Formatting.None)}");
            return result;
        }

        /////// OTHER /////////////////////////////////////////////////
        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<bool> ResetPasswordAsync(ApplicationUser user, string token, string newPassword)
        {
            await ApplyAuditInfoForUpdateAsync(user);
            var res = await _userManager.ResetPasswordAsync(user, token, newPassword);
            return res.Succeeded;
        }

        public async Task<bool> IsEmailConfirmedAsync(ApplicationUser user)
        {
            return await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<bool> ConfirmEmailAsync(ApplicationUser user, string token)
        {
            await ApplyAuditInfoForUpdateAsync(user);
            var res = await _userManager.ConfirmEmailAsync(user, token);
            return res.Succeeded;
        }

        public async Task<bool> SaveNewRefreshTokenAsync(ApplicationUser user, TokenData refreshToken)
        {
            user.RefreshToken = refreshToken.Token;
            user.RefreshTokenExpirationDate = refreshToken.Expiration;
            await ApplyAuditInfoForUpdateAsync(user);
            var res = await _userManager.UpdateAsync(user);
            return res.Succeeded;
        }

        public async Task<bool> InvalidateRefreshTokenAsync(ApplicationUser user)
        {
            user.RefreshToken = "";
            user.RefreshTokenExpirationDate = DateTime.UtcNow.AddDays(-1.0);
            await ApplyAuditInfoForUpdateAsync(user);
            var res = await _userManager.UpdateAsync(user);
            return res.Succeeded;
        }

        public async Task<bool> AddToRoleAsync(ApplicationUser user, string role)
        {
            var res = await _userManager.AddToRoleAsync(user, role);
            return res.Succeeded;
        }

        public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }
    }
}