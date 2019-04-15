using FluentValidation.Attributes;
using Validation.Validation.Validators;

namespace Validation.Models
{
    [Validator(typeof(FluentOrderValidator))]
    public class FluentOrder
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Discount { get; set; }
    }
}