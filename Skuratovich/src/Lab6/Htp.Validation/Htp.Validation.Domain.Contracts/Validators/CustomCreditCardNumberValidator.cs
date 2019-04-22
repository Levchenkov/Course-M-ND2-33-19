using System;
using System.Linq;
using FluentValidation.Resources;
using FluentValidation.Validators;

namespace Htp.Validation.Domain.Contracts.Validators
{
    public class CustomCreditCardNumberValidator : PropertyValidator
    {
        public CustomCreditCardNumberValidator() : base("{PropertyName} invalid card number")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var ccNumber = context.PropertyValue as string;
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
        }
    }
}
