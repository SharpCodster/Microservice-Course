using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using VivaioInCloud.Common.Abstraction.Contexts;
using VivaioInCloud.Common.Abstraction.Repositories;
using VivaioInCloud.Common.Services;
using VivaioInCloud.Identity.Abstraction.Services;
using VivaioInCloud.Identity.Entities.Models;

namespace VivaioInCloud.Identity.Services.Services
{
    public class ApplicationRoleService : BaseAuditableService<ApplicationRole>, IApplicationRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public ApplicationRoleService(
            RoleManager<ApplicationRole> roleManager,
            IRequestContextProvider requestContextProvider,
            IAsyncRepository<ApplicationRole> repository,
            IUnitOfWork unitOfWork,
            ILogger<ApplicationRoleService> logger
            ) : base(requestContextProvider, repository, unitOfWork, logger)
        {
            _roleManager = roleManager;
        }

        public async Task<ApplicationRole> FindByNameAsync(string roleName)
        {
            return await _roleManager.FindByNameAsync(roleName);
        }

        public override async Task<ApplicationRole> CreateAsync(ApplicationRole entity)
        {
            _logger.LogTrace($"ApplicationRoleService.CreateAsync({entity.Name})");
            await ValidateForCreateOrThrowAsync(entity);
            await BeforeCreateAsync(entity);
            await ApplyAuditInfoForCreateAsync(entity);

            var res = await _roleManager.CreateAsync(entity);

            if (!res.Succeeded)
            {
                throw new Exception("Qualcosa è andato storto");
            }
            var result = await GetByIdAsync(entity.Id);
            await AfterCreateAsync(result);
            _logger.LogTrace($"ApplicationRoleService.CreateAsync returned: {entity.Name}");
            return result;
        }

        protected override async Task<ApplicationRole> UpdateCoreAsync(ApplicationRole entity)
        {
            _logger.LogTrace($"ApplicationRoleService.UpdateCoreAsync(JsonConvert.SerializeObject(entity, Formatting.None))");
            await ValidateForUpdateOrThrowAsync(entity);
            await BeforeUpdateAsync(entity);
            await ApplyAuditInfoForUpdateAsync(entity);
            await _roleManager.UpdateAsync(entity);
            await AfterUpdateAsync(entity);
            _logger.LogTrace($"ApplicationRoleService.UpdateCoreAsync returned: JsonConvert.SerializeObject(entity, Formatting.None)");
            return entity;
        }
    }
}
