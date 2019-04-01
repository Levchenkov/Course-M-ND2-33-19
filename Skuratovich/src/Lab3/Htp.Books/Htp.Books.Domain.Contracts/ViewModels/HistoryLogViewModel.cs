using System;
using System.ComponentModel.DataAnnotations;

namespace Htp.Books.Domain.Contracts.ViewModels
{
    public class HistoryLogViewModel
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Actually { get; set; }
        [Display(Name = "Entity Id")]
        public string EntityId { get; set; }
        [Display(Name = "Entity Type")]
        public string EntityType { get; set; }
        public DateTime UpdateTime { get; set; }

        public BookViewModel CurrentBook { get; set; }

        public BookViewModel OriginBook { get; set; }
    }
}
