using Newtonsoft.Json;
using System;
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

        public void DelBook(int id) => Books.Remove(GetBookById(id));

        public Book GetBookById(int id) => Books.FirstOrDefault(c => c.BookId == id);

        public int GetBookId(Book book) => book.BookId;
        
    }
}