using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcValidation.Models
{
    public class TotalAmountValidationAttribute : ValidationAttribute, IClientValidatable
    {
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = "You can't pay less than $15.",
                ValidationType = "totalamount"
            };

            rule.ValidationParameters.Add("totalamount", 15);
            rule.ValidationParameters.Add("amountfield", "Amount");
            rule.ValidationParameters.Add("discountfield", "Discount");

            yield return rule;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var amountValue = (decimal?)context.ObjectType.GetProperty("Amount").GetValue(context.ObjectInstance);
            var discountValue = (decimal?)context.ObjectType.GetProperty("Discount").GetValue(context.ObjectInstance);

            if(amountValue - discountValue < 15)
            {
                return new ValidationResult("You can't pay less than $15.", new[] { "Amount", "Discount" });
            }

            return ValidationResult.Success;
        }
    }
}