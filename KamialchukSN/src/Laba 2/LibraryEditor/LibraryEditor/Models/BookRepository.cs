using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryEditor.Models
{
    public class BookRepository : IRepository<Book>
    {
        private List<Book> data;
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
            fileHandler.Save(data);
        }

        public void Edit(int id, Book entity)
        {
            var changeEntity = data.First(x => x.Id == id);
            var index = data.IndexOf(changeEntity);
            if (index != -1)
                data[index] = entity;
            fileHandler.Save(data);
        }

        public void Delete(int id)
        {
            data.RemoveAll(x => x.Id == id);
            fileHandler.Save(data);
        }

        public void SaveChanges()
        {
            fileHandler.Save(data.ToList());
        }

    }
}