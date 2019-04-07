using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public enum Genre
    {
        Fantastic,
        Novel,
        Poem
    }
    public enum Lanuages
    {
        English,
        Russian,
        German
    }
    public class Book
    {
        [Required]
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        [Required]
        public DateTime? Created { get; set; }
        public Genre? Genre { get; set; }
        public bool IsPaper { get; set; }
        public Lanuages? Languages { get; set; }
        public bool? DeliveryRequired { get; set; }
    }
}