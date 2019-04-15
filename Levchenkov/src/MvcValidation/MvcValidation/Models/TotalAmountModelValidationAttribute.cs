using System.ComponentModel.DataAnnotations;

namespace MvcValidation.Models
{
    public class TotalAmountModelValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var order = (Order)value;

            if(order.Amount - order.Discount < 15)
            {
                return false;
            }
            return true;
        }
    }
}