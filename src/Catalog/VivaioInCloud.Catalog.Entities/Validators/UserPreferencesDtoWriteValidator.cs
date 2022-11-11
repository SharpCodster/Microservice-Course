using FluentValidation;
using VivaioInCloud.Catalog.Entities.Dtos;

namespace VivaioInCloud.Catalog.Entities.Validators
{
    public class UserPreferencesDtoWriteValidator : AbstractValidator<UserPreferenceDtoWrite>
    {
        public UserPreferencesDtoWriteValidator()
        {
            RuleFor(x => x.ItemTypeId).Must(x => x == null || System.Guid.TryParse(x, out System.Guid _));
        }
    }
}

