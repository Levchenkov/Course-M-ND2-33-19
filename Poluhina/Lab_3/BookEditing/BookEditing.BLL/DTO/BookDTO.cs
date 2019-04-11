using System;
using System.Collections.Generic;

namespace BookEditing.BLL.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public string Genre { get; set; }
        public bool IsPaper { get; set; }
        public bool DeliveryRequred { get; set; }
        public virtual List<LanguageDTO> Languages { get; set; }
    }
}
