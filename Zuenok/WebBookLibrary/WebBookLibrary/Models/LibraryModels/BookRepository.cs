using System;
using System.Collections.Generic;
using System.Linq;

namespace WebBookLibrary.Models.LibraryModels
{
    public class BookRepository : IRepository<Book>
    {
        private readonly IFileHandler fileHandler;

        private IList<Book> Books { get; set; }

        public BookRepository(IFileHandler fileHandler)
        {
            this.fileHandler = fileHandler;
            Books = fileHandler.Load().ToList();
        }

        public Book Get(int id)
        {
            var result = Books.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                return result;
            }

            throw new Exception("Element not found.");
        }

        public List<Book> GetBooks() => Books as List<Book>;

        public void Add(Book entity)
        {
            Books.Add(entity);
        }

        public void Edit(Book entity)
        {
            Delete(entity.Id);
            Add(entity);
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