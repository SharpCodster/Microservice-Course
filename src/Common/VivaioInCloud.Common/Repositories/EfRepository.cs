using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VivaioInCloud.Common.Abstraction.Entities;
using VivaioInCloud.Common.Abstraction.Repositories;

namespace VivaioInCloud.Common.Repositories
{
    public abstract class EfRepository<T> : IAsyncRepository<T> where T : class, IIdentified
    {
        protected readonly DbContext _dbContext;
        private readonly ISpecificationEvaluator _specificationEvaluator;
        protected readonly ILogger<EfRepository<T>> _logger;

        public EfRepository(DbContext dbContext, ISpecificationEvaluator specificationEvaluator, ILogger<EfRepository<T>> logger)
        {
            _dbContext = dbContext;
            _specificationEvaluator = specificationEvaluator;
            _logger = logger;
        }

        public virtual async Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            _logger.LogTrace($"EfRepository.GetByIdAsync({id})");
            return await _dbContext.Set<T>().FirstOrDefaultAsync(_ => _.Id == id, cancellationToken: cancellationToken);
        }

        public virtual async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogTrace("EfRepository.ListAllAsync()");
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }
        public virtual async Task<int> CountAllAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogTrace("EfRepository.CountAllAsync()");
            return await _dbContext.Set<T>().CountAsync(cancellationToken);
        }

        public virtual async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            _logger.LogTrace($"EfRepository.ListAsync({spec.ToString()})");
            IQueryable<T> queryable = ApplySpecification(spec, false);
            return await queryable.ToListAsync(cancellationToken);
        }

        public virtual async Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            _logger.LogTrace($"EfRepository.CountAsync({spec.ToString()})");
            IQueryable<T> queryable = ApplySpecification(spec, true);
            return await queryable.CountAsync(cancellationToken);
        }

        protected virtual IQueryable<T> ApplySpecification(ISpecification<T> specification, bool evaluateCriteriaOnly = false)
        {
            return _specificationEvaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), specification, evaluateCriteriaOnly);
            //return specification.GetQuery(_dbContext.Set<T>().AsQueryable(), !evaluateCriteriaOnly);
        }

        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            _logger.LogTrace($"EfRepository.AddAsync(JsonConvert.SerializeObject(entity, Formatting.None))");
            if (String.IsNullOrEmpty(entity.Id) || !Guid.TryParse(entity.Id, out Guid output))
            {
                entity.Id = Guid.NewGuid().ToString();
            }
            var res = await _dbContext.Set<T>().AddAsync(entity);
            int rowsAfected = await SaveChangesAsync(cancellationToken);
            _logger.LogTrace($"EfRepository.AddAsync affected {rowsAfected} rows)");
            return res.Entity;
        }

        public virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entitiesList, CancellationToken cancellationToken = default)
        {
            _logger.LogTrace($"EfRepository.AddRangeAsync(JsonConvert.SerializeObject(entitiesList, Formatting.None))");
            foreach (var entity in entitiesList)
            {
                if (String.IsNullOrEmpty(entity.Id) || !Guid.TryParse(entity.Id, out Guid output))
                {
                    entity.Id = Guid.NewGuid().ToString();
                }
            }
            await _dbContext.Set<T>().AddRangeAsync(entitiesList);
            int rowsAfected = await SaveChangesAsync(cancellationToken);
            _logger.LogTrace($"EfRepository.AddRangeAsync affected {rowsAfected} rows)");
            return entitiesList;
        }

        public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _logger.LogTrace($"EfRepository.UpdateAsync(JsonConvert.SerializeObject(entity, Formatting.None))");
            _dbContext.Entry(entity).State = EntityState.Modified;
            //_dbContext.Set<T>().Update(entity);
            int rowsAfected = await SaveChangesAsync(cancellationToken);
            _logger.LogTrace($"EfRepository.UpdateAsync affected {rowsAfected} rows)");
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<T> entitiesList, CancellationToken cancellationToken = default)
        {
            _logger.LogTrace($"EfRepository.UpdateRangeAsync(JsonConvert.SerializeObject(entitiesList, Formatting.None))");
            _dbContext.Set<T>().UpdateRange(entitiesList);
            int rowsAfected = await SaveChangesAsync(cancellationToken);
            _logger.LogTrace($"EfRepository.UpdateRangeAsync affected {rowsAfected} rows)");
        }

        public virtual async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _logger.LogTrace($"EfRepository.DeleteAsync(JsonConvert.SerializeObject(entity, Formatting.None))");
            _dbContext.Set<T>().Remove(entity);
            int rowsAfected = await SaveChangesAsync(cancellationToken);
            _logger.LogTrace($"EfRepository.DeleteAsync affected {rowsAfected} rows)");
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<T> entitiesList, CancellationToken cancellationToken = default)
        {
            _logger.LogTrace($"EfRepository.DeleteRangeAsync(JsonConvert.SerializeObject(entitiesList, Formatting.None))");
            _dbContext.Set<T>().RemoveRange(entitiesList);
            int rowsAfected = await SaveChangesAsync(cancellationToken);
            _logger.LogTrace($"EfRepository.DeleteRangeAsync affected {rowsAfected} rows)");
        }

        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogTrace("EfRepository.SaveChangesAsync()");
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

