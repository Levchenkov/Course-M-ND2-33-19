using System;
using System.Collections.Generic;
using System.Linq;

namespace WebBookLibrary.Models.LibraryModels
{
    public class BookRepository : IRepository<Book>
    {
        private readonly IFileHandler fileHandler;

        public BookRepository(IFileHandler fileHandler)
        {
            this.fileHandler = fileHandler;
            Books = fileHandler.Load().ToList();
        }

        private IList<Book> Books { get; }

        public Book Get(int id)
        {
            var result = Books.FirstOrDefault(x => x.Id == id);
            if (result != null) return result;

            throw new Exception("Element not found.");
        }

        public IEnumerable<Book> GetBooks()
        {
            return Books;
        }

        public void Add(Book entity)
        {
            Books.Add(entity);
        }

        public void Edit(Book entity)
        {
            var changeEntity = Books.First(x => x.Id == entity.Id);
            var index = Books.IndexOf(changeEntity);
            if (index > -1) Books[index] = entity;
        }

        public void Delete(int id)
        {
            var book = Get(id);
            Books.Remove(book);
        }

        public void SaveChanges()
        {
            fileHandler.Save(Books.ToList());
        }
    }
}