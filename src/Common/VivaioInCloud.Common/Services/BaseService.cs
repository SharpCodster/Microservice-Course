using Ardalis.Specification;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VivaioInCloud.Common.Abstraction.Entities;
using VivaioInCloud.Common.Abstraction.Repositories;
using VivaioInCloud.Common.Abstraction.Services;
using VivaioInCloud.Common.Json;

namespace VivaioInCloud.Common.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class, IIdentified
    {
        protected readonly IAsyncRepository<TEntity> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ILogger<BaseService<TEntity>> _logger;

        public BaseService(IAsyncRepository<
            TEntity> repository,
            IUnitOfWork unitOfWork,
            ILogger<BaseService<TEntity>> logger)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _logger = logger;
        }

        public virtual async Task<TEntity> GetByIdAsync(string id)
        {
            _logger.LogTrace($"BaseService.GetByIdAsync({id})");
            var result = await _repository.GetByIdAsync(id);
            return result;
        }

        public virtual async Task<IEnumerable<TEntity>> ListAllAsync()
        {
            _logger.LogTrace($"BaseService.ListAllAsync()");
            var result = await _repository.ListAllAsync();
            return result;
        }

        public virtual async Task<int> CountAllAsync()
        {
            _logger.LogTrace($"BaseService.CountAllAsync()");
            var result = await _repository.CountAllAsync();
            return result;
        }

        public virtual async Task<IEnumerable<TEntity>> ListAsync(ISpecification<TEntity> specification)
        {
            _logger.LogTrace($"BaseService.GetByIdAsync({specification.CacheKey})");
            var result = await _repository.ListAsync(specification);
            return result;
        }

        public virtual async Task<int> CountAsync(ISpecification<TEntity> specification)
        {
            _logger.LogTrace($"BaseService.CountAsync({specification.CacheKey})");
            var result = await _repository.CountAsync(specification);
            return result;
        }

        /////// CREATE /////////////////////////////////////////////////
        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            _logger.LogTrace($"BaseService.CreateAsync(...)");
            using (IUnitOfWorkScope scope = _unitOfWork.BeginScope())
            {
                await ValidateForCreateOrThrowAsync(entity);
                await BeforeCreateAsync(entity);
                await ApplyAuditInfoForCreateAsync(entity);
                TEntity result = await _repository.AddAsync(entity);
                await AfterCreateAsync(result);
                scope.Commit();
                _logger.LogTrace($"BaseService.CreateAsync ended");
                return result;
            }
        }

        public virtual async Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            _logger.LogTrace($"BaseService.CreateRangeAsync(...)");

            using (IUnitOfWorkScope scope = _unitOfWork.BeginScope())
            {
                foreach (var entity in entities)
                {
                    await ValidateForCreateOrThrowAsync(entity);
                    await BeforeCreateAsync(entity);
                    await ApplyAuditInfoForCreateAsync(entity);
                }
                IEnumerable<TEntity> results = await _repository.AddRangeAsync(entities);
                foreach (var result in results)
                {
                    await AfterCreateAsync(result);
                }
                scope.Commit();
                _logger.LogTrace($"BaseService.CreateRangeAsync ended)");
                return results;
            }
        }

        protected virtual async Task ValidateForCreateOrThrowAsync(TEntity entity)
        {
            if (string.IsNullOrEmpty(entity.Id) || !Guid.TryParse(entity.Id, out Guid parsed))
            {
                _logger.LogDebug($"BaseService.ValidateForCreateOrThrowAsync: entity.Id == null");
                throw new InvalidDataException("");
            }
            await Task.CompletedTask;
        }

        protected virtual async Task BeforeCreateAsync(TEntity entity)
        {
            await Task.CompletedTask;
        }

        protected virtual async Task AfterCreateAsync(TEntity entity)
        {
            await Task.CompletedTask;
        }

        protected virtual async Task ApplyAuditInfoForCreateAsync(TEntity entity)
        {
            await Task.CompletedTask;
        }

        /////// UPDATE /////////////////////////////////////////////////
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _logger.LogTrace($"BaseService.UpdateAsync(...)");
            using (IUnitOfWorkScope scope = _unitOfWork.BeginScope())
            {
                TEntity result = await UpdateCoreAsync(entity);
                scope.Commit();
                _logger.LogTrace($"BaseService.UpdateAsync ended)");
                return result;
            }
        }

        public virtual async Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            _logger.LogTrace($"BaseService.UpdateRangeAsync(...)");

            using (IUnitOfWorkScope scope = _unitOfWork.BeginScope())
            {
                foreach (var entity in entities)
                {
                    await ValidateForUpdateOrThrowAsync(entity);
                    await BeforeUpdateAsync(entity);
                    await ApplyAuditInfoForUpdateAsync(entity);
                }
                await _repository.UpdateRangeAsync(entities);
                foreach (var result in entities)
                {
                    await AfterUpdateAsync(result);
                }
                scope.Commit();
                _logger.LogTrace($"BaseService.UpdateRangeAsync ended");
                return entities;
            }
        }

        protected virtual async Task<TEntity> UpdateCoreAsync(TEntity entity)
        {
            _logger.LogTrace($"BaseService.UpdateCoreAsync(...)");
            await ValidateForUpdateOrThrowAsync(entity);
            await BeforeUpdateAsync(entity);
            await ApplyAuditInfoForUpdateAsync(entity);
            await _repository.UpdateAsync(entity);
            await AfterUpdateAsync(entity);
            _logger.LogTrace($"BaseService.UpdateCoreAsync ended");
            return entity;
        }

        protected virtual async Task ValidateForUpdateOrThrowAsync(TEntity entity)
        {
            await Task.CompletedTask;
        }

        protected virtual async Task BeforeUpdateAsync(TEntity entity)
        {
            await Task.CompletedTask;
        }

        protected virtual async Task AfterUpdateAsync(TEntity entity)
        {
            await Task.CompletedTask;
        }

        protected virtual async Task ApplyAuditInfoForUpdateAsync(TEntity entity)
        {
            await Task.CompletedTask;
        }

        /////// PATCH /////////////////////////////////////////////////
        public virtual async Task<TEntity> PatchAsync(string id, Dictionary<string, object> valuesToPatch)
        {
            _logger.LogTrace($"BaseService.PatchAsync({id}, ...)");
            using (IUnitOfWorkScope scope = _unitOfWork.BeginScope())
            {
                TEntity entity = await _repository.GetByIdAsync(id);
                JsonConvert.PopulateObject(valuesToPatch.ToJson(), entity);
                var result = await UpdateCoreAsync(entity);
                scope.Commit();
                _logger.LogTrace($"BaseService.PatchAsync ended");
                return result;
            }
        }

        /////// DELETE /////////////////////////////////////////////////
        public virtual async Task DeleteAsync(string id)
        {
            _logger.LogTrace($"BaseService.DeleteAsync({id})");
            using (IUnitOfWorkScope scope = _unitOfWork.BeginScope())
            {
                TEntity entity = await _repository.GetByIdAsync(id);
                await ValidateForDeleteOrThrowAsync(entity);
                await BeforeDeleteAsync(entity);
                await ApplyAuditForDeleteAsync(entity);
                await _repository.DeleteAsync(entity);
                await AfterDeleteAsync(entity);
                scope.Commit();
            }
            _logger.LogTrace($"BaseService.DeleteAsync ended");
        }

        protected virtual async Task ValidateForDeleteOrThrowAsync(TEntity entity)
        {
            await Task.CompletedTask;
        }

        protected virtual async Task BeforeDeleteAsync(TEntity entity)
        {
            await Task.CompletedTask;
        }

        protected virtual async Task AfterDeleteAsync(TEntity entity)
        {
            await Task.CompletedTask;
        }

        protected virtual async Task ApplyAuditForDeleteAsync(TEntity entity)
        {
            await Task.CompletedTask;
        }
        //////////////////////////////////////////////////  
    }
}
