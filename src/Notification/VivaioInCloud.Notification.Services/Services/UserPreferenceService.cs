using Microsoft.Extensions.Logging;
using VivaioInCloud.Common.Abstraction.Repositories;
using VivaioInCloud.Common.Services;
using VivaioInCloud.Notification.Abstraction.Services;
using VivaioInCloud.Notification.Entities.Models;

namespace VivaioInCloud.Notification.Services.Services
{
    public class UserPreferenceService : BaseService<UserPreference>, IUserPreferenceService
    {
        public UserPreferenceService(
            IAsyncRepository<UserPreference> repository,
            IUnitOfWork unitOfWork,
            ILogger<UserPreferenceService> logger
            ) : base(repository, unitOfWork, logger)
        {
        }
    }
}
