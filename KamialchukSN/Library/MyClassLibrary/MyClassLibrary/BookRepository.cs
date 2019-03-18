using System;
using System.Collections.Generic;
using System.Linq;

namespace MyClassLibrary
{
    public class BookRepository : IRepository<Book>
    {
        private IList<Book> data;
        private IFileHandler fileHandler;

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

        public void Edit(Book entity)
        {
            Delete(entity.Id);
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
