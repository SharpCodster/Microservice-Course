using FluentValidation;
using VivaioInCloud.Identity.Entities.Requests;

namespace VivaioInCloud.Identity.Entities.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Password).NotNull();
        }
    }
}
