using VivaioInCloud.Identity.Entities.Dtos;
using VivaioInCloud.Identity.Entities.Models;

namespace VivaioInCloud.Identity.Abstraction.Services
{
    public interface IUserRegistrationService
    {
        Task<ApplicationUser> RegisterNewUser(RegisterUserRequest request);
        Task<ApplicationUser> RegisterNewAdmin(RegisterAdminRequest request);
    }
}
