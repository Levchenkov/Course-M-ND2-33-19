using System.Collections.Generic;

namespace BookEditing.BLL.DTO
{
    public class LanguageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<BookDTO> Books { get; set; }
    }
}
