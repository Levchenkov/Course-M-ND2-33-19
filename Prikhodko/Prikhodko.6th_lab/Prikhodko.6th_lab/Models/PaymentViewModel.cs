using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prikhodko._6th_lab.Models
{
    public class PaymentViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int PostCode { get; set; }
        public string Email { get; set; }
        public decimal Sum { get; set; }
        public string Description { get; set; }
        public string CreditCardNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public int CVV { get; set; }
    }
}
