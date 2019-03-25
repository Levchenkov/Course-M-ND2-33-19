using System.Collections.Generic;

namespace BookLibraryCRUD
{
    /// <summary>
    ///     Actually it is the book library itself
    /// </summary>
    public class LibraryContext
    {
        public IList<Book> Books { get; set; }
    }
}