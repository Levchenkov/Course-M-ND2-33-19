using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Library.Data.Contracts.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public virtual Profile Profile { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
