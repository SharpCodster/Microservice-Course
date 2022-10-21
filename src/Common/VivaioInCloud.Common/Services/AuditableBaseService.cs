using Microsoft.Extensions.Logging;
using VivaioInCloud.Common.Abstraction.Contexts;
using VivaioInCloud.Common.Abstraction.Entities;
using VivaioInCloud.Common.Abstraction.Repositories;
using VivaioInCloud.Common.Entities.Models;

namespace VivaioInCloud.Common.Services
{
    public abstract class AuditableBaseService<TEntity> : BaseService<TEntity>
        where TEntity : class, IIdentified, IAuditableUtc
    {
        protected readonly IRequestContextProvider _requestContextProvider;

        public AuditableBaseService(
            IRequestContextProvider requestContextProvider,
            IAsyncRepository<TEntity> repository,
            IUnitOfWork unitOfWork,
            ILogger<AuditableBaseService<TEntity>> logger
            ) : base(repository, unitOfWork, logger)
        {
            _requestContextProvider = requestContextProvider;
        }

        public override async Task DeleteAsync(string id)
        {
            _logger.LogTrace($"AuditableBaseService.DeleteAsync({id})");
            using (IUnitOfWorkScope scope = _unitOfWork.BeginScope())
            {
                TEntity entity = await _repository.GetByIdAsync(id);

                await ValidateForDeleteOrThrowAsync(entity);
                await BeforeDeleteAsync(entity);
                await ApplyAuditForDeleteAsync(entity);
                TEntity result = await UpdateCoreAsync(entity);
                await AfterDeleteAsync(entity);
                scope.Commit();
            }
        }

        protected override async Task ApplyAuditInfoForCreateAsync(TEntity entity)
        {
            RequestContext requestContext = _requestContextProvider.GetRequestContexAsync();

            entity.CreatedAtUtc = entity.UpdatedAtUtc = DateTime.UtcNow;
            entity.CreatedBy = entity.UpdatedBy = requestContext?.User?.UserName ?? "NA";
            entity.IsDeleted = false;

            await base.ApplyAuditInfoForCreateAsync(entity);
        }

        protected override async Task ApplyAuditInfoForUpdateAsync(TEntity entity)
        {
            RequestContext requestContext = _requestContextProvider.GetRequestContexAsync();

            entity.UpdatedAtUtc = DateTime.UtcNow;
            entity.UpdatedBy = requestContext?.User?.UserName ?? "NA";

            await base.ApplyAuditInfoForUpdateAsync(entity);
        }

        protected override async Task ApplyAuditForDeleteAsync(TEntity entity)
        {
            entity.IsDeleted = true;
            await ApplyAuditInfoForUpdateAsync(entity);
            await base.ApplyAuditForDeleteAsync(entity);
        }
    }
}
