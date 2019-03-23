using System;
using System.Collections.Generic;
using Lab2.Contracts;
using Lab2.Entities;
using Lab2.Entities.Models;

namespace Lab2.Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(IBookFileHandler fileHandler) : base (fileHandler) { }

        public void CreateBook(Book book)
        {
            Create(book);
            Save();
        }

        public void DeleteBook(Book book)
        {
            Delete(book);
            Save();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return GetAll();
        }

        public Book GetBookById(int id)
        {
            var result = FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                return result;
            }

            throw new Exception("Element not found");
        }

        public void UpdateBook(Book book)
        {
            Update(book);
            Save();
        }
    }
}
