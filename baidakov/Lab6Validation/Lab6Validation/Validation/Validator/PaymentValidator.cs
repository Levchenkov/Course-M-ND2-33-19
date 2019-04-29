using Lab6Validation.Models;
using System;
using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;
using System.Linq;

namespace Lab6Validation.Validation
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(model => model.FirstName).NotEmpty().WithMessage("Enter first name");
            RuleFor(model => model.MiddleName).NotNull().WithMessage("Enter middle name");
            RuleFor(model => model.LastName).NotEmpty().WithMessage("Enter last name");
            RuleFor(model => model.Address).NotEmpty().WithMessage("Enter address").Matches(@"[\w',-\\/.\s]+");
            RuleFor(model => model.City).NotEmpty().WithMessage("Enter City").Matches(@"^[a-zA-Z-\s]+$");
            RuleFor(model => model.Country).NotEmpty().WithMessage("Enter Country").Matches(@"^[a-zA-Z-\s]+$");
            RuleFor(model => model.PostCode).NotEmpty().WithMessage("Enter 5-digit Post code").Matches(@"^[0-9]{5}$");
            RuleFor(model => model.Email).NotEmpty().WithMessage("Enter your email").EmailAddress();
           // RuleFor(model => model.Amount).NotNull().WithMessage("Enter amount");
            RuleFor(model => model.Amount).NotNull().WithMessage("Enter amount").InclusiveBetween(0.01, 99999.99).WithMessage("Invalid amount (from 0.01 to 99999.99)");
            RuleFor(model => model.Description).Length(0, 250).WithMessage("Max 250 symbols");
            RuleFor(a => a.CreditCardNumber)
                .NotNull()
                .WithMessage("Enter not null value")
                .Matches(@"^[0-9]{16}$")
                .WithMessage("Enter 16-digit CreditCardNumber")
                .Must(ccNumber => {
                    int sum = 0;
                    int n;
                    bool alternate = false;
                    char[] nx = ccNumber.ToArray();
                    for (int i = ccNumber.Length - 1; i >= 0; i--)
                    {
                        n = int.Parse(nx[i].ToString());

                        if (alternate)
                        {
                            n *= 2;

                            if (n > 9)
                            {
                                n = (n % 10) + 1;
                            }
                        }
                        sum += n;
                        alternate = !alternate;
                    }
                    return (sum % 10 == 0);
                }).WithMessage("CreditCardNumber does't match to Luhn's formula");
            RuleFor(model => model.ExpirationYear).NotNull().WithMessage("Enter ExpirationYear").Must(x => x >= DateTime.Now.Year).WithMessage("Invalid Expiration Year"); ;
            RuleFor(model => model.ExpirationMonth).NotNull().WithMessage("Enter ExpirationYear").Must(x => x > 0 && x < 13).Must((model, month, context) =>
                {
                    var date = new DateTime(model.ExpirationYear, month, DateTime.Now.Day);
                    return date >= DateTime.Now.Date;
                }).WithMessage("Invalid Expiration date");
            RuleFor(model => model.SecurityCode).NotEmpty().WithMessage("Enter 3-digit CVV code").Matches(@"^[0-9]{3}$");
        }
    }
}