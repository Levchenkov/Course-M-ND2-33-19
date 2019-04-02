using System.Collections.Generic;

namespace Htp.Books.Data.Contracts.Entities
{
    public class Genre : Entity<int>
    {
        public string Title { get; set; }
        public ICollection<Book> Books {get; set; }
    }
}
