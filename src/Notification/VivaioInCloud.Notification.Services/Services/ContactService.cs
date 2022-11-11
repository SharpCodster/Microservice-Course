using Microsoft.Extensions.Logging;
using VivaioInCloud.Common.Abstraction.Contexts;
using VivaioInCloud.Common.Abstraction.Repositories;
using VivaioInCloud.Common.Services;
using VivaioInCloud.Notification.Abstraction.Services;
using VivaioInCloud.Notification.Entities.Models;

namespace VivaioInCloud.Notification.Services.Services
{
    public class ContactService : BaseAuditableService<Contact>, IContactService
    {
        public ContactService(
            IRequestContextProvider requestContextProvider,
            IAsyncRepository<Contact> repository,
            IUnitOfWork unitOfWork,
            ILogger<ContactService> logger
            ) : base(requestContextProvider, repository, unitOfWork, logger)
        {
        }

    }
}
