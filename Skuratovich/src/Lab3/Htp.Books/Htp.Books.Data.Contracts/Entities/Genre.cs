using System.Collections.Generic;

namespace Htp.Books.Data.Contracts.Entities
{
    public class Genre : Entity<int>
    {
        //public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Book> Books {get; set; }
    }
}
