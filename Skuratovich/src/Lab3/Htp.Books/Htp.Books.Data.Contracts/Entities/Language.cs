using System.Collections.Generic;

namespace Htp.Books.Data.Contracts.Entities
{
    public class Language : Entity<int>
    {
        public string Title { get; set; }
        public ICollection<BookLanguage> BookLanguages { get; set; }
    }
}
