using System;
using FluentValidation;
using Htp.Validation.Domain.Contracts.Comands;

namespace Htp.Validation.Domain.Contracts.Validators
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
                .MaximumLength(16)
                .CustomCreditCard();

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

//First Name - обязательное.
//Middle Name - обязательное.
//Last Name - обязательное.
//Address - обязательное, разрешены буквы, цифры, пробелы, знаки препинания, дефисы и все прочее, что используется в адресах.
//City - обязательное, разрешены только буквы, пробелы, дефисы.
//Country - обязательное, разрешены только буквы, пробелы, дефисы.
//Post Code - обязательное, 5 цифр.
//Email - обязательное, электронный ящик.
//Amount - сумма платежа, обязательное, от 0.01 и до 99999.99.
//Description - описание платежа, опционально, не длиннее 250 символов.
//Credit Card Number - 16 цифр, удовлетворяет формуле: https://en.wikipedia.org/wiki/Luhn_algorithm. Кастомная серверная + клиентская валидации.
//Expiration Month - месяц, от 1 и до 12, больше текущей даты.
//Expiration Year - год, больше текущей даты.
//Security Code - CVV, 3 цифры. добавляем только create
