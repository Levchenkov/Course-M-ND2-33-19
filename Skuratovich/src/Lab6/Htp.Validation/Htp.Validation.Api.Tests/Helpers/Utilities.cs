using System.Collections.Generic;
using Htp.Validation.Data.Contracts.Entities;
using Htp.Validation.Data.EntityFramework;

namespace Htp.Validation.Api.Tests.Helpers
{
    public static class Utilities
    {
        public static void InitializeDbForTests(ApplicationDbContext db)
        {
            db.Payments.AddRange(GetSeedingMessages());
            db.SaveChanges();
        }

        public static List<Payment> GetSeedingMessages()
        {
            return new List<Payment>()
            {
                new Payment()
                {
                    Id = 1,
                    FirstName = "1 - First name",
                    MiddleName = "Middle name",
                    LastName = "Last name",
                    Address = "Address",
                    City = "City",
                    Country = "Country",
                    PostCode = "12345",
                    Email = "a@a.by",
                    Amount = 123,
                    Description = "Description",
                    CreditCardNumber = "4111111111111111",
                    ExpirationMonth = "01",
                    ExpirationYear = "20",
                    SecurityCode = "123"
                },
                new Payment()
                {
                    Id = 2,
                    FirstName = "2 - First name",
                    MiddleName = "2 - Middle name",
                    LastName = "2 - Last name",
                    Address = "2 - Address",
                    City = "2 - City",
                    Country = "2 - Country",
                    PostCode = "12345",
                    Email = "b@b.by",
                    Amount = 10,
                    Description = "2 - Description",
                    CreditCardNumber = "5555555555554444",
                    ExpirationMonth = "04",
                    ExpirationYear = "21",
                    SecurityCode = "543"
                }
            };
        }
    }
}
