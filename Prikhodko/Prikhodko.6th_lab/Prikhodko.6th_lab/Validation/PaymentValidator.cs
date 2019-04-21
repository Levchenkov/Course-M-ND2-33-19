using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Prikhodko._6th_lab.Models;

namespace Prikhodko._6th_lab.Validation
{
    public class PaymentValidator : AbstractValidator<PaymentViewModel>
    {
        public PaymentValidator()
        {
            string dateValidationMessage = "Expiration date must be later than the current date";

            RuleFor(x => x.Address).NotEmpty().Matches(@"[A-aZ-z \d-!\#$%&'()*+,./:;<=>?@[\\\]_`{|}~]+")
                .WithMessage("The address can include letters, digits, quotes, and commas");
            RuleFor(x => x.CVV).NotEmpty().InclusiveBetween(100, 999).WithMessage("CVV must contain 3 digits");
            RuleFor(x => x.City).NotEmpty().Matches(@"[A-aZ-z\s-]+");
            RuleFor(x => x.Country).NotEmpty().Matches(@"[A-aZ-z\s-]+");
            RuleFor(x => x.CreditCardNumber).Length(16).Must(BeAValidCreditCardNumber);
            RuleFor(x => x.Description).Length(0, 250);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.ExpirationMonth).GreaterThanOrEqualTo(DateTime.Now.Month).When(x => x.ExpirationYear == DateTime.Now.Year).WithMessage(dateValidationMessage).LessThanOrEqualTo(12);
            RuleFor(x => x.ExpirationYear).GreaterThanOrEqualTo(DateTime.Now.Year - 2000).WithMessage(dateValidationMessage);
            RuleFor(x => x.FirstName).NotEmpty().Matches(@"[A-aZ-z\s-]+");
            RuleFor(x => x.LastName).NotEmpty().Matches(@"[A-aZ-z\s-]+");
            RuleFor(x => x.MiddleName).NotEmpty().Matches(@"[A-aZ-z\s-]+");
            RuleFor(x => x.PostCode).NotEmpty().InclusiveBetween(10000, 99999).WithMessage("Post Code must contain 5 digits");
            RuleFor(x => x.Sum).NotEmpty();
        }

        private bool BeAValidCreditCardNumber(string number)
        {
            int sum = 0;
            int n;
            bool alternate = false;
            char[] nx = number.ToArray();
            for (int i = number.Length - 1; i >= 0; i--)
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
        }
}
}
