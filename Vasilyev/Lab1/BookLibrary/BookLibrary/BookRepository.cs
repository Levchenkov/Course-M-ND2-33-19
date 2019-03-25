using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BookLibrary
{
    public class BookRepository : IRepository<Book>
    {
        private readonly IList<Book> data;
        private string path = Directory.GetCurrentDirectory() + @"\books.json";
        private IJsonWorker jw;

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
                    new Book { Id = 1, Title = "Title1" },
                    new Book { Id = 2, Title = "Title2" },
                    new Book { Id = 3, Title = "Title3" },
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