using FluentValidation;
using VivaioInCloud.Notification.Entities.Dtos;

namespace VivaioInCloud.Notification.Entities.Validators
{
    public class UserPreferenceDtoWriteValidator : AbstractValidator<UserPreferenceDtoWrite>
    {
        public UserPreferenceDtoWriteValidator()
        {
            RuleFor(x => x.TypeId).NotNull().Must(x => System.Guid.TryParse(x, out System.Guid _));
        }
    }
}
