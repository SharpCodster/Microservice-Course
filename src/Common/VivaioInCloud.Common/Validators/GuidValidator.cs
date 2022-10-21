using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
