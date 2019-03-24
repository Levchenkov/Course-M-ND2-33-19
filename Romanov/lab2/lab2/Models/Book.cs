﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace lab2.Models
{
    public enum DeliviryRequired
    {
        curier,
        pickup
    }
    public enum LanguagesOfBooks
    {
        russian,
        english,
        italian,
    }
    public enum GenreOfBooks
    {
        fantastic,
        detective,
        novel
    }
    public class Book
    {
        public Book()
        {
            
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public GenreOfBooks Genre { get; set; }
        public bool IsPapper { get; set; }
        public LanguagesOfBooks Languages { get; set; }
        public DeliviryRequired Delivery { get; set; }
    }
}