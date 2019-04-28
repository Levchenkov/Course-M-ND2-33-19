using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Validation.Validation;

namespace Validation.Models
{
    [OrderModelValidation]
    public class Order : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "Title_Required", ErrorMessageResourceType = typeof(Localization))]
        [RegularExpression(@"[A-aZ-z \d-]+")]
        [StringLength(20, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [Range(100, 1000)]
        [Remote("ValidateAmount", "Order")]
        [TotalAmountValidation]
        public decimal? Amount { get; set; }

        [Required]
        [Range(10, 100)]
        public decimal? Discount { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var order = (Order) validationContext.ObjectInstance;

            if (order.Title.Contains("DUCK"))
            {
                yield return new ValidationResult("Don't use DUCK in the internet.", new []{ nameof(Title)});
            }
        }
    }
}