using Ardalis.Specification;
using Microsoft.Extensions.Logging;
using VivaioInCloud.Common.Abstraction.Entities;
using VivaioInCloud.Common.Repositories;

namespace VivaioInCloud.Notification.Infrastructure.Repositories
{
    public class NotificationRepository<T> : EfRepository<T>
        where T : class, IIdentified
    {
        public NotificationRepository(
            ApplicationDbContext dbContext,
            ISpecificationEvaluator evaluator,
            ILogger<NotificationRepository<T>> logger
            ) : base(dbContext, evaluator, logger)
        {
        }
    }
}
