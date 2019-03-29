using System.Collections.Generic;

namespace Htp.Books.Data.Contracts.Entities
{
    public class Genre : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Book> Books {get; set; }
    }
}
