using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryEditor.Models
{
    public class BookRepository : IRepository<Book>
    {
        private IFileHandler fileHandler;

        public List<Book> Data { get; private set; }

        public BookRepository(IFileHandler fileHandler)
        {
            this.fileHandler = fileHandler;
            Data = fileHandler.Load().ToList();
        }

        public Book Get(int id)
        {
            var result = Data.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                return result;
            }
            throw new Exception("Element not found");
        }

        public void Add(Book entity)
        {
            Data.Add(entity);
            fileHandler.Save(Data);
        }

        public void Edit(int id, Book entity)
        {
            var changeEntity = Data.First(x => x.Id == id);
            var index = Data.IndexOf(changeEntity);
            if (index != -1)
                Data[index] = entity;
            fileHandler.Save(Data);
        }

        public void Delete(int id)
        {
            Data.RemoveAll(x => x.Id == id);
            fileHandler.Save(Data);
        }

        public void SaveChanges()
        {
            fileHandler.Save(Data.ToList());
        }

    }
}