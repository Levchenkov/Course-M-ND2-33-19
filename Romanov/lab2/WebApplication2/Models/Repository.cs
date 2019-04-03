using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Repository : IRepositoryService
    {
        public Repository() => Books = new List<Book>();

        public int RepositoryId { get; set; }
        public List<Book> Books { get; set; }
        
        public void AddBook(Book book) => Books.Add(book);
        public void DeleteBook(int id) => Books.Remove(Books.Find(b => b.BookId == id));
        public Book GetBook(int id) => Books.FirstOrDefault(c => c.BookId == id);
        public void Update(Book book)
        {
            var id = Books.IndexOf(Books.First(x => x.BookId == book.BookId));
            Books[id] = book;
        }
    }
}