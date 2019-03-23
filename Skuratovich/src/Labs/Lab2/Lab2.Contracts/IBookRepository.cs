using System.Collections.Generic;
using Lab2.Entities.Models;

namespace Lab2.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}
