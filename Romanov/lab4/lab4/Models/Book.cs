using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab4.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; } 
        public string ApplicationUser { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedTime { get; set; }

        public Book()
        {
            Created = DateTime.Now;
        }
    }
}