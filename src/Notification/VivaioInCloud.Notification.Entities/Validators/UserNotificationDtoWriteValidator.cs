using FluentValidation;
using VivaioInCloud.Notification.Entities.Dtos;

namespace VivaioInCloud.Notification.Entities.Validators
{
    public class UserNotificationDtoWriteValidator : AbstractValidator<UserNotificationDtoWrite>
    {
        public UserNotificationDtoWriteValidator()
        {
            RuleFor(x => x.UserId).NotNull().Must(x => System.Guid.TryParse(x, out System.Guid _));
            RuleFor(x => x.Message).NotNull().MinimumLength(3);
        }
    }
}
