using FluentValidation;
using System;

namespace ClientServerValidation.Models.Entities
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name cannot be empty.");

            RuleFor(x => x.MiddleName).NotEmpty().WithMessage("Middle Name cannot be empty.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name cannot be empty.");

            RuleFor(x => x.Address).NotEmpty().WithMessage("Address cannot be empty.")
                                    .Matches(@"^[a-zA-Z0-9-.,/ ]*$").WithMessage("The Address is not a valid.");

            RuleFor(x => x.City).NotEmpty().WithMessage("City cannot be empty.")
                                .Matches(@"^[a-zA-Z- ]*$").WithMessage("The City is not a valid.");

            RuleFor(x => x.Country).NotEmpty().WithMessage("Country cannot be empty.")
                                    .Matches(@"^[a-zA-Z- ]*$").WithMessage("The Country is not a valid.");

            RuleFor(x => x.PostCode).Matches(@"^[0-9]{5}$").WithMessage("The PostCode is not a valid.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be empty.")
                                .EmailAddress().WithMessage("The email is not a valid email address.");

            RuleFor(x => x.Amount).InclusiveBetween(0.01, 99999.99).WithMessage("Amount is required to be from 0.01 to 99999,99.");

            RuleFor(x => x.Description).Length(1, 250).WithMessage("The description must be between 1 and 250 characters.");

            RuleFor(x => x.CreditCardNumber).CreditCard().WithMessage("The CreditCard is not a valid.");

            RuleFor(x => x.ExpirationMonth).InclusiveBetween(1, 12).WithMessage("The ExpirationMonth is not a valid.");

            RuleFor(x => x.ExpirationYear).GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("The ExpirationYear is not a valid.");

            RuleFor(x => x.SecurityCode).Matches(@"^[0-9]{3}$").WithMessage("The SecurityCode is not a valid.");
        }
    }
}
