using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using VivaioInCloud.Notification.Entities.Dtos;

namespace VivaioInCloud.Notification.Entities.Validators
{
    public class ContactDtoWriteValidator : AbstractValidator<ContactDtoWrite>
    {
        public ContactDtoWriteValidator()
        {
            RuleFor(x => x.Id).NotNull().Must(x =>System.Guid.TryParse(x, out System.Guid _));
            RuleFor(x => x.Name).NotNull().MinimumLength(3).MaximumLength(30);
            RuleFor(x => x.Surname).NotNull().MinimumLength(3).MaximumLength(30);
            RuleFor(x => x.Email).NotNull().EmailAddress();
        }
    }
}
