using System;
namespace Htp.Validation.Domain.Contracts.Comands
{
    public class CreatePaymentRequest
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
