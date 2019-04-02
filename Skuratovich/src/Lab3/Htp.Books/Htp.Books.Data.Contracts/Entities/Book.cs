using System;
using System.Collections.Generic;

namespace Htp.Books.Data.Contracts.Entities
{
    public class Book : Entity<int>
    {
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public string Author { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual bool IsPaper { get; set; }
        public virtual ICollection<BookLanguage> BookLanguages { get; set; }
        public virtual bool DeliveryRequired { get; set; }
        public byte[] RowVersion { get; set; }

        public long LongRowVersion
        {
            get => BitConverter.ToInt64(RowVersion, 0);
            set => RowVersion = BitConverter.GetBytes(value);
        }
    }
}
