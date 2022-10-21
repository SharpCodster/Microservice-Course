using FluentValidation;
using VivaioInCloud.Identity.Entities.Dtos;

namespace VivaioInCloud.Identity.Entities.Validators
{
    public class ApplicationRoleDtoValidator : AbstractValidator<ApplicationRoleDtoWrite>
    {
        public ApplicationRoleDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(3);
        }
    }
}

