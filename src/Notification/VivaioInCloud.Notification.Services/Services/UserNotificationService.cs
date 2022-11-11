using Microsoft.Extensions.Logging;
using VivaioInCloud.Common.Abstraction.Contexts;
using VivaioInCloud.Common.Abstraction.Repositories;
using VivaioInCloud.Common.Services;
using VivaioInCloud.Notification.Abstraction.Services;
using VivaioInCloud.Notification.Entities.Models;

namespace VivaioInCloud.Notification.Services.Services
{
    public class UserNotificationService : BaseAuditableService<UserNotification>, IUserNotificationService
    {
        public UserNotificationService(
            IRequestContextProvider requestContextProvider,
            IAsyncRepository<UserNotification> repository,
            IUnitOfWork unitOfWork,
            ILogger<UserNotificationService> logger
            ) : base(requestContextProvider, repository, unitOfWork, logger)
        {
        }

    }
}
