using System.Collections.Generic;
using System.Threading.Tasks;
using Htp.BooksAPI.Data.Contracts.Entities;

namespace Htp.BooksAPI.Data.Contracts
{
    public interface IBookRepository : IRepository<Book>
    {
        //IEnumerable<Book> GetAllBooks();
        //ITransaction BeginTransaction();
        //Task<Book> GetBook(int id);
        Task<Book> GetAsync(int id);
    }
}
