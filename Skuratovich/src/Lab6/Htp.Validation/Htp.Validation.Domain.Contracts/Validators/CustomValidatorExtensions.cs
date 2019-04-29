using FluentValidation;

namespace Htp.Validation.Domain.Contracts.Validators
{
    public static class CustomValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> CustomCreditCard<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CustomCreditCardNumberValidator());
        }
    }
}
