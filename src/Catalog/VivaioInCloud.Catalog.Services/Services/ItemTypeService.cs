using Microsoft.Extensions.Logging;
using VivaioInCloud.Catalog.Abstraction.Services;
using VivaioInCloud.Catalog.Entities.Models;
using VivaioInCloud.Catalog.Services.Specifications;
using VivaioInCloud.Common.Abstraction.Contexts;
using VivaioInCloud.Common.Abstraction.Repositories;
using VivaioInCloud.Common.Exceptions;
using VivaioInCloud.Common.Services;

namespace VivaioInCloud.Catalog.Services.Services
{
    public class ItemTypeService : AuditableBaseService<ItemType>, IItemTypeService
    {
        public ItemTypeService(
            IRequestContextProvider requestContextProvider,
            IAsyncRepository<ItemType> repository,
            IUnitOfWork unitOfWork,
            ILogger<ItemTypeService> logger
            ) : base(requestContextProvider, repository, unitOfWork, logger)
        {
        }

        protected override async Task ValidateForCreateOrThrowAsync(ItemType entity)
        {
            await CheckIfAlredyExists(entity);
            await base.ValidateForCreateOrThrowAsync(entity);
        }
        protected async override Task ValidateForUpdateOrThrowAsync(ItemType entity)
        {
            await CheckIfAlredyExists(entity);
            await base.ValidateForUpdateOrThrowAsync(entity);
        }

        private async Task CheckIfAlredyExists(ItemType entity)
        {
            entity.Name = entity.Name.Trim().ToLowerInvariant().Replace(' ', '-');

            DuplicatedItemTypeSpecification spec = new DuplicatedItemTypeSpecification(entity.Id, entity.Name);
            int count = await _repository.CountAsync(spec);

            if (count != 0)
            {
                throw new DuplicatedItemException();
            }
        }
    }
}
