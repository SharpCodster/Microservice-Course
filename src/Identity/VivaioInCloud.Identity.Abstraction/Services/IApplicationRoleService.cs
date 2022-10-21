using VivaioInCloud.Common.Abstraction.Services;
using VivaioInCloud.Identity.Entities.Models;

namespace VivaioInCloud.Identity.Abstraction.Services
{
    public interface IApplicationRoleService : IBaseService<ApplicationRole>
    {
        Task<ApplicationRole> FindByNameAsync(string roleName);
    }
}
