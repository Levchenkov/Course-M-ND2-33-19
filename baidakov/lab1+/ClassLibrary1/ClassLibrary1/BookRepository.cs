using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1
{
    public class BookRepository : IRepository<Book>
    {
        private readonly IList<Book> data;
        private readonly IFileHandler fileHandler;

        public BookRepository(IFileHandler fileHandler)
        {
            this.fileHandler = fileHandler;
            data = fileHandler.Load().ToList();
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

        public void Add(Book entity)
        {
            data.Add(entity);
        }

        public IList<Book> View()
        {
            return data;
        }

        public void Edit(int id, Book entity)
        {
            var book = Get(id);
            data.Remove(book);
            Add(entity);
        }

        public void Delete(int id)
        {
            var book = Get(id);
            data.Remove(book);
        }

        public void SaveChanges()
        {
            fileHandler.Save(data.ToList());
        }
    }
}