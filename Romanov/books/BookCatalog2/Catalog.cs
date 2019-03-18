using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookCatalog2
{
    public class Catalog 
    {
        public List<Book> Books { get; set; }

        public class Book
        {
            public string Title { get; set; }
            public int Id { get; set; }
        }
        public static void ShowAllBooks(Catalog catalog)
        {
            foreach (var book in catalog.Books)
            {
                Console.WriteLine($"Id: {book.Id}\t Title: {book.Title}");
            }
        }
        public static Catalog InitCatalog()
        {
            Catalog catalog = new Catalog();
            catalog.Books = new List<Book>();
            return catalog;
        }

        public Book Get(Catalog catalog, int x)
        {
            return catalog.Books[x];
        }

        public static void Add(Catalog catalog, Book book)
        {
            catalog.Books.Add(book);
        }
        public static void Delete(Catalog catalog, int x)
        {
            catalog.Books.RemoveAt(x);
        }
        public static void Edit(Catalog catalog, int x, Book book)
        {
            catalog.Books[x] = book;
        }
    }
    
}
