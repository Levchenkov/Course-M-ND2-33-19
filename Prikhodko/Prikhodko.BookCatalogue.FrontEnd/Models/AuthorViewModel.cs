using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prikhodko.BookCatalogue.FrontEnd.Models
{
    public class AuthorViewModel
    {
        public virtual int AuthorId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual ICollection<BookViewModel> Books { get; set; }
    }
}