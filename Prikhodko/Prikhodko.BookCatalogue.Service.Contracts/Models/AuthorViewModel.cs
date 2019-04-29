using System.Collections.Generic;

namespace Prikhodko.BookCatalogue.Service.Contracts.Models
{
    public class AuthorViewModel
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual ICollection<BookViewModel> Books { get; set; }
    }
}