using System.Collections.Generic;

namespace BookLibraryCRUD
{
    public class LibraryContext
    {
        public IList<Book> Books { get; set; }
    }
}