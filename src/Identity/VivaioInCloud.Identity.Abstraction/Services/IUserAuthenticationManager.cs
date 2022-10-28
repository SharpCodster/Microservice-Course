using VivaioInCloud.Identity.Entities.Dtos;
using VivaioInCloud.Identity.Entities.Requests;
using VivaioInCloud.Identity.Model.Responses;

namespace VivaioInCloud.Identity.Abstraction.Services
{
    public interface IUserAuthenticationManager
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<LoginResponse> RefreshTokenAsync(RefreshTokenRequest request);

        Task<string> GenerateEmailConfirmationTokenAsync(string email);
        Task<bool> ConfirmEmailAsync(ConfirmEmailRequest request);

        Task<string> GeneratePasswordResetTokenAsync(string email);
        Task<bool> ConfirmResetPasswordAsync(ResetPasswordRequest request);

        Task<bool> RegisterNewUser(RegisterUserRequest request);
        Task<bool> DeactivateUser(string usertId);
    }
}
