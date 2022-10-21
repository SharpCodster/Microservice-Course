using FluentValidation;
using VivaioInCloud.Identity.Entities.Dtos;

namespace VivaioInCloud.Identity.Entities.Validators
{
    public class ApplicationUserDtoValidator : AbstractValidator<ApplicationUserDtoWrite>
    {
        public ApplicationUserDtoValidator()
        {
            //RuleFor(x => x.Name).NotNull().MinimumLength(3);
        }
    }
}
