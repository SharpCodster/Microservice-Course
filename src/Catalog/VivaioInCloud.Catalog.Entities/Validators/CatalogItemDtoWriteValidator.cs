using FluentValidation;
using VivaioInCloud.Catalog.Entities.Dtos;

namespace VivaioInCloud.Catalog.Entities.Validators
{
    public class CatalogItemDtoWriteValidator : AbstractValidator<CatalogItemDtoWrite>
    {
        public CatalogItemDtoWriteValidator()
        {
            RuleFor(x => x.Title).NotNull().MinimumLength(3).MaximumLength(20);
            RuleFor(x => x.Description).NotNull().MinimumLength(3);
            RuleFor(x => x.CategoryId).Must(x => x == null || System.Guid.TryParse(x, out System.Guid _));
        }
    }
}
