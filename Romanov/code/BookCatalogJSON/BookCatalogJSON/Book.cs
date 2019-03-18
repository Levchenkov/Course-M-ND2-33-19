using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace BookCatalogJSON
{
    public class Book
    {
        public Book() { }
        public Book(string name)
        {
            Name = name;
        }
        public Book(string name, int year)
        {
            Year = year;
            Name = name;
        }
        public Book(string name, int year, string author)
        {
            Name = name;
            Year = year;
            Author = author;
        }
        
        public string Name { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        
    }
}
