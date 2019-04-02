using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Htp.Books.Domain.Contracts.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        public DateTime Created { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        [Display(Name = "Is paper")]
        public bool IsPaper { get; set; }
        [Display(Name = "Languages")]
        public ICollection<int> LanguageIds { get; set; }
        [Display(Name = "Delivery required")]
        public bool DeliveryRequired { get; set; }
        public byte[] RowVersion { get; set; }
        public long LongRowVersion { get; set; }
        [Display(Name = "History log")]
        public string HistoryLog { get; set; }

        //public List<SelectListItem> Genres { get; set;  }
        //public List<SelectListItem> Languages { get; set; }

    }
}
