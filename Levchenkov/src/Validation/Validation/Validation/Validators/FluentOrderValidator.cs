using FluentValidation;
using Validation.Models;

namespace Validation.Validation.Validators
{
    public class FluentOrderValidator : AbstractValidator<FluentOrder>
    {
        public FluentOrderValidator()
        {
            RuleFor(x => x.Title).NotEmpty().Length(3, 20).Matches(@"[A-aZ-z \d-]+");
            RuleFor(x => x.Amount).InclusiveBetween(100, 1000).NotNull();
            RuleFor(x => x.Discount).NotNull().InclusiveBetween(10, 100);
        }
    }
}