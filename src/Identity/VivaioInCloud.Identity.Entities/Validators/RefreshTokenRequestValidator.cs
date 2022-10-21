using FluentValidation;
using VivaioInCloud.Identity.Entities.Requests;

namespace VivaioInCloud.Identity.Entities.Validators
{
    public class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
    {
        public RefreshTokenRequestValidator()
        {
            RuleFor(x => x.AccessToken).NotNull();
            RuleFor(x => x.RefreshToken).NotNull();
        }
    }
}
