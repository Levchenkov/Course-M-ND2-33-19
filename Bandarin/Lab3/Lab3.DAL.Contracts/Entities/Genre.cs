using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL.Contracts.Entities
{
    public enum Genres { Adventure, Detective, Fantasy, Horror, Humor, SciFi, Romance }
    public class Genre
    {
        public int Id { get; set; }
        public Genres Name { get; set; }

        public ICollection<Book> Books { get; set; }


    }
}
