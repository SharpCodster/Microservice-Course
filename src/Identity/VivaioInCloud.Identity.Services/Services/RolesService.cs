using Ardalis.Specification;
using Microsoft.AspNetCore.Identity;
using VivaioInCloud.Identity.Abstraction.Services;
using VivaioInCloud.Identity.Entities.Models;

namespace VivaioInCloud.Identity.Services.Services
{
    public class RolesService : IRolesService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RolesService(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<ApplicationRole> GetByIdAsync(string id)
        {
            return await _roleManager.FindByIdAsync(id);
        }

        public async Task<ApplicationRole> GetByNameAsync(string role)
        {
            return await _roleManager.FindByNameAsync(role);
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }

        public async Task<IEnumerable<ApplicationRole>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApplicationRole>> ListAsync(ISpecification<ApplicationRole> spec)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountAsync(ISpecification<ApplicationRole> spec)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationRole> CreateAsync(ApplicationRole entity)
        {
            var res = await _roleManager.CreateAsync(entity);
            return await GetByNameAsync(entity.Name);
        }

        public async Task<ApplicationRole> UpdateAsync(ApplicationRole role)
        {
            var res = await _roleManager.UpdateAsync(role);
            return await GetByIdAsync(role.Id);
        }

        public async Task<ApplicationRole> PatchAsync(string id, Dictionary<string, object> valuesToPatch)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(string id)
        {
            var res = await GetByIdAsync(id);
            await _roleManager.DeleteAsync(res);
        }
    }
}

