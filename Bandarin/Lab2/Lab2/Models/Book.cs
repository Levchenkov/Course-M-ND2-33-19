using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;

namespace Lab2.Models
{
    public class Books
    {
        
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string Author { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        public GenreType Genre { get; set; }   
        public IList<SelectListItem> GenresAvailable { get; set; } 
        public bool IsPaper { get; set; }
        //public Language Language { get; set; } 
        public int[] Languages { get; set; }
        public IList<SelectListItem> LanguageAvailable { get; set; }

        public DeliveryType DeliveryRequired { get; set; }
    }
}