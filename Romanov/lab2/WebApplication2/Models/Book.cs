using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public enum Genre
    {
        Fantastic,
        Poem,
        Novel
    }
    public class Book
    {
        [Required]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public Genre Genre { get; set; }
        public bool IsPaper { get; set; }
        [Required]
        public string[] Languages { get; set; }
        public bool Delivery { get; set; }
    }
}