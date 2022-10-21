using Ardalis.Specification;
using Microsoft.Extensions.Logging;
using VivaioInCloud.Common.Abstraction.Entities;
using VivaioInCloud.Common.Repositories;

namespace VivaioInCloud.Catalog.Infrastructure.Repositories
{
    public class CatalogRepository<T> : EfRepository<T>
        where T : class, IIdentified
    {
        public CatalogRepository(
            ApplicationDbContext dbContext,
            ISpecificationEvaluator evaluator,
            ILogger<CatalogRepository<T>> logger
            ) : base(dbContext, evaluator, logger)
        {
        }
    }
}
