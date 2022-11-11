using VivaioInCloud.Common.Abstraction.Services;
using VivaioInCloud.Identity.Entities.Models;
using VivaioInCloud.Identity.Model.Models;

namespace VivaioInCloud.Identity.Abstraction.Services
{
    public interface IApplicationUserService : IBaseService<ApplicationUser>
    {
        Task<ApplicationUser> GetByEmailAsync(string id);

        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);

        Task<ApplicationUser> CreateUserAsync(ApplicationUser user, string password);

        Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
        Task<bool> ResetPasswordAsync(ApplicationUser user, string token, string newPassword);

        Task<bool> IsEmailConfirmedAsync(ApplicationUser user);
        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task<bool> ConfirmEmailAsync(ApplicationUser user, string token);

        Task<bool> SaveNewRefreshTokenAsync(ApplicationUser user, TokenData refreshToken);
        Task<bool> InvalidateRefreshTokenAsync(ApplicationUser user);

        Task<bool> AddToRoleAsync(ApplicationUser user, string role);

        Task<IList<string>> GetRolesAsync(ApplicationUser user);
    }
}
