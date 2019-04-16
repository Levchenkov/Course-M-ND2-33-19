using System.Collections.Generic;

namespace Lab.Library.Data.Contracts.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public GenreEnum GenreNamEnum { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }

    public enum GenreEnum
    {
        Classic = 1,
        Business,
        Detective,
        Fantasy,
        Humor,
        Science,
        Directories
    }
}
