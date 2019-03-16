using System.Collections.Generic;

namespace BookLibraryCRUD {
    public interface ILibrary : IRepository<Book>
    {
        bool Add(Book book);
        bool Edit(int id);
        bool Delete(int id);
        IEnumerable<Book> GetBooks();
    }
}