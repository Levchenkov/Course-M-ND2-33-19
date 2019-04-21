using System;
using FluentValidation;
using Htp.Validation.Domain.Contracts.Comands;

namespace Htp.Validation.Domain.Contracts.Validators
{
    public class CreatePaymentRequestValidator : AbstractValidator<CreatePaymentRequest>
    {
        public CreatePaymentRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
                //.Length(0, 10);
            //RuleFor(x => x.Email).EmailAddress();
            //RuleFor(x => x.Age).InclusiveBetween(18, 60);
        }
    }
}
