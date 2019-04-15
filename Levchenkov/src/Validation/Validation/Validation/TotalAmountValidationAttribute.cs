using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Validation.Models;

namespace Validation.Validation
{
    public class TotalAmountValidationAttribute : 
        ValidationAttribute, 
        IClientValidatable
    {
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = "You can't pay less than 15$.",
                ValidationType = "totalamount"
            };

            rule.ValidationParameters.Add("value", 15);
            rule.ValidationParameters.Add("amountfield", nameof(Order.Amount));
            rule.ValidationParameters.Add("discountfield", nameof(Order.Discount));

            yield return rule;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var order = (Order)validationContext.ObjectInstance;

            if (order.Amount - order.Discount < 15)
            {
                return new ValidationResult("You can't pay less than 15$.", new []{ nameof(Order.Amount), nameof(Order.Discount)});
            }

            return ValidationResult.Success;
        }
    }
}