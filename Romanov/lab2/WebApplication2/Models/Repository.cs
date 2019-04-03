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

        public void DeleteBook(int id) => Books.RemoveAll(c => c.BookId == id);

        public Book GetBook(int id) => Books.FirstOrDefault(c => c.BookId == id);

        public Book Update(Book book)
        {
            var book2 = Books.First(x => x.BookId == book.BookId);
            var id = Books.IndexOf(book2);
            if (id != -1)
             return   Books[id] = book;
        }
    }
}