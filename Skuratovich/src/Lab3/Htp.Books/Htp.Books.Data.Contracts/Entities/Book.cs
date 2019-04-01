using System;
using System.Collections.Generic;

namespace Htp.Books.Data.Contracts.Entities
{
    public class Book : Entity<int>
    {
        //public int Id { get; set; }
        public string Title { get; set; }
        public virtual string Description { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public bool IsPaper { get; set; }
        public ICollection<BookLanguage> BookLanguages { get; set; }
        public bool DeliveryRequired { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
