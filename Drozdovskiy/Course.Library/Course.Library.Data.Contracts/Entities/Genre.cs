using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Library.Data.Contracts.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
