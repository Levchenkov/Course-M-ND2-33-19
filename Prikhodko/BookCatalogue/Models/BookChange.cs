using System;

namespace Prikhodko.BookCatalogue.Data.Contracts.Models
{
    public class BookChange
    {
        public virtual int BookChangeId { get; set; }
        public virtual string ChangedProperty { get; set; }
        public virtual string NewValue { get; set; }
        public virtual DateTime TimeOfChange { get; set; }
        public virtual Book Book { get; set; }
    }
}
