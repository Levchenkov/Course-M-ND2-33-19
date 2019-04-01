using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prikhodko.BookCatalogue.Data.Contracts.Models
{
    public class Language
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; } //this will represent short name of the language (RU for Russian, EN for English, etc.)
        public virtual ICollection<Book> Books { get; set; }
    }
}
