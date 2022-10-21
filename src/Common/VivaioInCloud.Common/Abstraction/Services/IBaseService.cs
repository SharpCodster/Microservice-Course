using Ardalis.Specification;
using VivaioInCloud.Common.Abstraction.Entities;

namespace VivaioInCloud.Common.Abstraction.Services
{
    public interface IBaseService<TEntity> where TEntity : class, IIdentified
    {
        Task<TEntity> GetByIdAsync(string id);

        Task<IEnumerable<TEntity>> ListAllAsync();
        Task<int> CountAllAsync();

        Task<IEnumerable<TEntity>> ListAsync(ISpecification<TEntity> specification);
        Task<int> CountAsync(ISpecification<TEntity> specification);

        Task<TEntity> CreateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities);

        Task<TEntity> PatchAsync(string id, Dictionary<string, object> valuesToPatch);

        Task DeleteAsync(string id);
    }
}
