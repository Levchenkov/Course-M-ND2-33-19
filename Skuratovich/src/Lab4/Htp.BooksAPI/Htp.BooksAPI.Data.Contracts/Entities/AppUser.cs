using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Htp.BooksAPI.Data.Contracts.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Book> CreatedBooks { get; set; }
        public virtual ICollection<Book> UpdatedBooks { get; set; }
    }
}
