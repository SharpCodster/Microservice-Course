using Microsoft.Extensions.Logging;
using VivaioInCloud.Catalog.Abstraction.Services;
using VivaioInCloud.Catalog.Entities.Models;
using VivaioInCloud.Common.Abstraction.Contexts;
using VivaioInCloud.Common.Abstraction.Repositories;
using VivaioInCloud.Common.Services;

namespace VivaioInCloud.Catalog.Services.Services
{
    public class CatalogItemService : AuditableBaseService<CatalogItem>, ICatalogItemService
    {
        public CatalogItemService(
            IRequestContextProvider requestContextProvider,
            IAsyncRepository<CatalogItem> repository,
            IUnitOfWork unitOfWork,
            ILogger<CatalogItemService> logger
            ) : base(requestContextProvider, repository, unitOfWork, logger)
        {
        }

    }
}
