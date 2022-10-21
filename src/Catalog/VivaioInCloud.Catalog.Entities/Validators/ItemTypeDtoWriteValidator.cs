using FluentValidation;
using VivaioInCloud.Catalog.Entities.Dtos;

namespace VivaioInCloud.Catalog.Entities.Validators
{
    public class ItemTypeDtoWriteValidator : AbstractValidator<ItemTypeDtoWrite>
    {
        public ItemTypeDtoWriteValidator()
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(3);
        }
    }
}
