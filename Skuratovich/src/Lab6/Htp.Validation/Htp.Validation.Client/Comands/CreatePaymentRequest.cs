using System;
using System.ComponentModel.DataAnnotations;
using Htp.Validation.Client.Validators;

namespace Htp.Validation.Client.Comands
{
    public class CreatePaymentRequest
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        [Display(Name = "Post Code")]
        public string PostCode { get; set; }
        public string Email { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        [Display(Name = "Credit Card Number")]
        [CustomCreditCardNumber(ErrorMessage = "Invalid card number")]
        [CreditCard]
        public string CreditCardNumber { get; set; }

        [Display(Name = "Expiration Month")]
        public string ExpirationMonth { get; set; }

        [Display(Name = "Expiration Year")]
        public string ExpirationYear { get; set; }

        [Display(Name = "CVV")]
        public string SecurityCode { get; set; }
    }
}
