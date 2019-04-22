using System;
using FluentValidation;
using Htp.Validation.Client.Comands;

namespace Htp.Validation.Client.Validators
{
    public class CreatePaymentRequestValidator : AbstractValidator<CreatePaymentRequest>
    {
        public CreatePaymentRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("The 'First name' is required");
            RuleFor(x => x.MiddleName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Address).NotEmpty().Matches("[\\w\\s,./-]+");

            RuleFor(x => x.City).NotEmpty().Matches("^[a-zA-Z]+(?:[\\s-][a-zA-Z]+)*$");
            RuleFor(x => x.Country).NotEmpty().Matches("^[a-zA-Z]+(?:[\\s-][a-zA-Z]+)*$");
            RuleFor(x => x.PostCode)
                .NotEmpty()
                .Length(5)
                .Matches("[0-9]{5}")
                .WithMessage("The 'Post code' must contain 5 digits");
            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x => x.Amount)
                .NotEmpty()
                .ExclusiveBetween(0, 100000)
                .ScalePrecision(2, 7);

            RuleFor(x => x.Description).MaximumLength(250);

            RuleFor(x => x.CreditCardNumber)
                .NotEmpty()
                .Matches("[0-9]{16}")
                .WithMessage("The 'Credit Card Number' must contain 16 digits")
                .MaximumLength(16);

            RuleFor(x => x.ExpirationYear)
                .NotEmpty()
                .WithMessage("Credit card expiry year is required")
                .Matches("19|[2-9][0-9]")
                .WithMessage("The 'Year' must be greather then '19'")
                .Must(x => Convert.ToInt32("20" + x) >= DateTime.Now.Year)
                .WithMessage("The credit card expiry year is invalid");

            RuleFor(x => x.ExpirationMonth)
                .NotEmpty()
                .WithMessage("Credit card expiry month is required")
                .Matches("0[1-9]|1[0-2]");

            RuleFor(x => x.ExpirationMonth)
                .Must(x => Convert.ToInt32(x) >= DateTime.Now.Month)
                .WithMessage("The credit card expiry month is invalid")
                .When(x => Convert.ToInt32("20" + x.ExpirationYear) == DateTime.Now.Year);

            RuleFor(x => x.SecurityCode)
                .NotEmpty()
                .Matches("[0-9]{3}")
                .MaximumLength(3);
        }
    }
}
