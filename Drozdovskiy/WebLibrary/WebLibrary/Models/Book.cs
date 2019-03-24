using System;
using System.Collections.Generic;
using System.Text;

namespace WebLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string Genre { get; set; }
        public bool IsPaper { get; set; }
        public string[] Languages { get; set; }
        public bool DeliveryRequired { get; set; }
    }

}
