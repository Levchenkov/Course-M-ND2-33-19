using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcValidation.Models
{
    //[TotalAmountModelValidation(ErrorMessage = "You can't pay less than $15.")]
    public class Order : IValidatableObject
    {
        public int Id
        {
            get;
            set;
        }

        [Required]
        [RegularExpression(@"[A-aZ-z \d-]+")]
        [StringLength(20, MinimumLength = 3)]
        [Remote("ValidateTitle", "Order")]
        public string Title
        {
            get;
            set;
        }

        [Range(typeof(decimal), "10.0", "100.0")]
        [TotalAmountValidation]
        public decimal? Amount
        {
            get;
            set;
        }

        [Range(typeof(decimal), "1.0", "10.0")]
        public decimal? Discount
        {
            get;
            set;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if(Amount > 50)
            {
                errors.Add(new ValidationResult("Amount should be more than $50", new[] { nameof(Amount) }));
            }

            return errors;
        }
    }
}