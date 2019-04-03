using BooksWebApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Models
{
    public class BookRepository : IRepository<Book>
    {
        private readonly IList<Book> data;
        //private string path = Directory.GetCurrentDirectory() + @"\books.json";
        private string path = HttpContext.Current.Server.MapPath("~/App_Data/books.json");
        private IJsonWorker jw;

        public IList<Book> Books { get { return data; } }

        public BookRepository()
        {
            jw = new JsonWorker();
            var fileinfo = new FileInfo(path);
            if (fileinfo.Exists)
            {
                data = jw.Load(path).ToList();
            }
            else
            {
                data = new List<Book>
                {
                    new Book { Id = 1, Title = "How to Win Friends and Influence People",
                        Description = "Книга представляет собой собрание практических советов и жизненных историй.",
                        Author = "Dale Harbison Carnegie", Created = new DateTime(1936,1,1),
                        Genre = Genre.Essay, IsPaper = true,  Languages = new[] { 3 }, DeliveryRequired = true },
                    new Book { Id = 2, Title = "CLR VIA C#", Description = "Book for C# programmers", Author = "Jeffrey Richter", Created = new DateTime(2006,1,1),
                        Genre = Genre.ReferenceBooks, IsPaper = true,  Languages = new[] { 1, 3 }, DeliveryRequired = true },
                    new Book { Id = 3, Title = "Cashflow Quadrant", Description = "Rich Dad's Guide to Financial Freedom", Author = "Robert Toru Kiyosaki", Created = new DateTime(2000,1,1),
                        Genre = Genre.Legend, IsPaper = true,  Languages = new[] { 1, 2, 3 }, DeliveryRequired = false },
                };
                jw.Save(path, data.ToList());
            }
        }

        public BookRepository(IJsonWorker jsonWorker) : base()
        {
            jw = jsonWorker;
            data = jw.Load(path).ToList();
        }

        public Book Get(int id)
        {
            var result = data.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                return result;
            }

            throw new Exception("Element not found");
        }

        public void Add(Book book)
        {
            if (!data.Contains(book))
            {
                data.Add(book);
            }
            else
                throw new Exception("Element alredy exists");
        }

        public void Change(Book book)
        {
            Delete(book.Id);
            Add(book);
        }

        public void Delete(int id)
        {
            var book = Get(id);
            data.Remove(book);
        }

        public void SaveChanges()
        {
            jw.Save(path, data.ToList());
        }
    }
}