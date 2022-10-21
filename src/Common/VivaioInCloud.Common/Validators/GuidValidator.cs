using FluentValidation;

namespace VivaioInCloud.Common.Validators
{
    public class GuidValidator : AbstractValidator<string>
    {
        public GuidValidator()
        {
            RuleFor(x => x).NotNull().Length(36).Must(x => Guid.TryParse(x, out Guid _));
        }
    }
}
