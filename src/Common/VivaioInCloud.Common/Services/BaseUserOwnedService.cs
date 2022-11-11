using Ardalis.Specification;
using Microsoft.Extensions.Logging;
using VivaioInCloud.Common.Abstraction.Contexts;
using VivaioInCloud.Common.Abstraction.Entities;
using VivaioInCloud.Common.Abstraction.Repositories;
using VivaioInCloud.Common.Entities.Models;
using VivaioInCloud.Common.Specifications;

namespace VivaioInCloud.Common.Services
{
    public class BaseUserOwnedService<TEntity> : BaseService<TEntity>
        where TEntity : class, IIdentified, IUserOwnedRecord
    {
        protected readonly IRequestContextProvider _requestContextProvider;

        public BaseUserOwnedService(
            IRequestContextProvider requestContextProvider,
            IAsyncRepository<TEntity> repository,
            IUnitOfWork unitOfWork,
            ILogger<BaseUserOwnedService<TEntity>> logger
            ) : base(repository, unitOfWork, logger)
        {
            _requestContextProvider = requestContextProvider;
        }

        public override async Task<TEntity> GetByIdAsync(string id)
        {
            RequestContext requestContext = await _requestContextProvider.GetRequestContexAsync();
            bool isAdmin = requestContext.User.UserRoles.Contains(SolutionConstants.Authorization.Roles.ADMIN);
            var entity = await base.GetByIdAsync(id);
            if (!isAdmin && entity.OwnerId != requestContext.User.UserName)
            {
                return null;
            }
            return entity;
        }

        public override async Task<IEnumerable<TEntity>> ListAllAsync()
        {
            RequestContext requestContext = await _requestContextProvider.GetRequestContexAsync();
            bool isAdmin = requestContext.User.UserRoles.Contains(SolutionConstants.Authorization.Roles.ADMIN);

            if (isAdmin)
            {
                return await base.ListAllAsync();
            }
            else
            {
                GetOnlyUserRecordsSpecification<TEntity> spec = new GetOnlyUserRecordsSpecification<TEntity>(requestContext.User.UserId);
                return await base.ListAsync(spec);
            }
        }

        public override async Task<int> CountAllAsync()
        {
            RequestContext requestContext = await _requestContextProvider.GetRequestContexAsync();
            bool isAdmin = requestContext.User.UserRoles.Contains(SolutionConstants.Authorization.Roles.ADMIN);

            if (isAdmin)
            {
                return await base.CountAllAsync();
            }
            else
            {
                GetOnlyUserRecordsSpecification<TEntity> spec = new GetOnlyUserRecordsSpecification<TEntity>(requestContext.User.UserId);
                return await base.CountAsync(spec);
            }
        }

        public override async Task<IEnumerable<TEntity>> ListAsync(ISpecification<TEntity> specification)
        {
            RequestContext requestContext = await _requestContextProvider.GetRequestContexAsync();
            bool isAdmin = requestContext.User.UserRoles.Contains(SolutionConstants.Authorization.Roles.ADMIN);

            if (!isAdmin)
            {
                specification.Query.Where(_ => _.OwnerId == requestContext.User.UserId);
            }

            return await base.ListAsync(specification);
        }

        public override async Task<int> CountAsync(ISpecification<TEntity> specification)
        {
            RequestContext requestContext = await _requestContextProvider.GetRequestContexAsync();
            bool isAdmin = requestContext.User.UserRoles.Contains(SolutionConstants.Authorization.Roles.ADMIN);

            if (!isAdmin)
            {
                specification.Query.Where(_ => _.OwnerId == requestContext.User.UserId);
            }

            return await base.CountAsync(specification);
        }

        protected override async Task ValidateForUpdateOrThrowAsync(TEntity entity)
        {
            RequestContext requestContext = await _requestContextProvider.GetRequestContexAsync();
            bool isAdmin = requestContext.User.UserRoles.Contains(SolutionConstants.Authorization.Roles.ADMIN);

            if (!isAdmin)
            {
                var dbEntity = await GetByIdAsync(entity.Id);
                if (dbEntity.OwnerId != requestContext.User.UserId)
                {
                    throw new ArgumentException("Entity not found");
                }
            }
            await base.ValidateForUpdateOrThrowAsync(entity);
        }

        protected override async Task ValidateForDeleteOrThrowAsync(TEntity entity)
        {
            RequestContext requestContext = await _requestContextProvider.GetRequestContexAsync();
            bool isAdmin = requestContext.User.UserRoles.Contains(SolutionConstants.Authorization.Roles.ADMIN);

            if (!isAdmin)
            {
                if (entity.OwnerId != requestContext.User.UserId)
                {
                    throw new ArgumentException("Entity not found");
                }
            }
            await base.ValidateForDeleteOrThrowAsync(entity);
        }

        protected override async Task ApplyAuditInfoForCreateAsync(TEntity entity)
        {
            RequestContext requestContext = await _requestContextProvider.GetRequestContexAsync();
            entity.OwnerId = requestContext.User.UserId;
            await base.ApplyAuditInfoForCreateAsync(entity);
        }
    }
}

