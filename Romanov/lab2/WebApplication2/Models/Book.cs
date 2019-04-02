using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public enum Genre
    {
        fantastic,
        poem,
        novel
    }
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public Genre Genre { get; set; }
        public bool IsPaper { get; set; }
        public string[] Languages { get; set; }
        public bool Delivery { get; set; }
    }
}