using System.Collections.Generic;

namespace Prikhodko.BookCatalogue.Data.Contracts.Models
{
    public class Author
    {
        public virtual int AuthorId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
