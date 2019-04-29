using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL.Contracts.Entities
{
    public enum Langua { Russian, English, Spanish, German, French}
    public class Language
    {
        public int Id { get; set; }
        public Langua Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
