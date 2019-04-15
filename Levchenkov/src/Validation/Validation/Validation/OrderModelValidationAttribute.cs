using System.ComponentModel.DataAnnotations;
using Validation.Models;

namespace Validation.Validation
{
    public class OrderModelValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var order = (Order) value;

            if (order.Amount - order.Discount <= 90)
            {
                return false;
            }

            return true;
        }
    }
}