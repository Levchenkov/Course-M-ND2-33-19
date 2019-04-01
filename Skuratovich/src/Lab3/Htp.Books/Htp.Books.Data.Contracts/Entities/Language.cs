using System.Collections.Generic;

namespace Htp.Books.Data.Contracts.Entities
{
    public class Language : Entity<int>
    {
        //public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<BookLanguage> BookLanguages { get; set; }
    }
}
