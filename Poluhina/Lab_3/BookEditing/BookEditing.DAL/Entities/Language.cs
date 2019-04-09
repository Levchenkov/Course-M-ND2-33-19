using System.Collections.Generic;

namespace BookEditing.DAL.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}