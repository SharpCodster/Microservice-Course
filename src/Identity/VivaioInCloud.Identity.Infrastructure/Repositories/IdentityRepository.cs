using Ardalis.Specification;
using Microsoft.Extensions.Logging;
using VivaioInCloud.Common.Abstraction.Entities;
using VivaioInCloud.Common.Repositories;

namespace VivaioInCloud.Identity.Infrastructure.Repositories
{
    public class IdentityRepository<T> : EfRepository<T>
        where T : class, IIdentified
    {
        public IdentityRepository(
            ApplicationDbContext dbContext,
            ISpecificationEvaluator evaluator,
            ILogger<IdentityRepository<T>> logger
            ) : base(dbContext, evaluator, logger)
        {
        }
    }
}
