using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Prikhodko.BookCatalogue.Data.Contracts.Models
{
    public class BookChange
    {
        public virtual int Id { get; set; }
        public virtual string ChangedProperty { get; set; }
        public virtual string NewValue { get; set; }
        public virtual DateTime TimeOfChange { get; set; }
    }
}
