﻿namespace ClientServerValidation.Models.Entities
{
    public class Payment
    {
        public string FirstName { get; set; }  
        public string MiddleName { get; set; } 
        public string LastName { get; set; }
        public string Address { get; set; } 
        public string City { get; set; }    
        public string Country { get; set; } 
        public string PostCode { get; set; }
        public string Email { get; set; } 
        public double? Amount { get; set; } 
        public string Description { get; set; }
        public string CreditCardNumber { get; set; } 
        public int ExpirationMonth { get; set; } 
        public int ExpirationYear { get; set; }  
        public string SecurityCode { get; set; }  
    }
}
