using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prikhodko.BookCatalogue.FrontEnd.Models
{
    public class LanguageViewModel
    {
        public virtual int LanguageId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; } //this will represent short name of the language (RU for Russian, EN for English, etc.)
    }
}
