using Ardalis.Specification;
using VivaioInCloud.Identity.Entities.Models;

namespace VivaioInCloud.Identity.Abstraction.Services
{
    public interface IRolesService
    {
        Task<ApplicationRole> GetByIdAsync(string id);
        Task<ApplicationRole> GetByNameAsync(string role);

        Task<IEnumerable<ApplicationRole>> ListAllAsync();
        Task<IEnumerable<ApplicationRole>> ListAsync(ISpecification<ApplicationRole> spec);
        Task<int> CountAsync(ISpecification<ApplicationRole> spec);
        Task<ApplicationRole> CreateAsync(ApplicationRole entity);
        Task<ApplicationRole> UpdateAsync(ApplicationRole entity);
        Task<ApplicationRole> PatchAsync(string id, Dictionary<string, object> valuesToPatch);
        Task DeleteAsync(string id);

        Task<bool> RoleExistsAsync(string roleName);
    }
}
