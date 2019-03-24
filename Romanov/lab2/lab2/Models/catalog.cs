using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab2.Models
{
    public class Catalog : IBookCatalogPossibility<Book>
    {
        public List<Book> Books { get; set; }
        
        public int Add(Book book)
        {
            Books.Add(book);
            return Books.Count;
        }

        public int Del(int index)
        {
            Books.RemoveAt(index);
            return Books.Count;
        }
        public Catalog()
        {
            Books = new List<Book>();
        }
    }
}