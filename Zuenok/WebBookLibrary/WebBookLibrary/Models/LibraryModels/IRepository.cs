using System.Collections.Generic;

namespace WebBookLibrary.Models.LibraryModels
{
    public interface IRepository<T>
    {
        T Get(int id);

        void Add(T entity);
        void Edit(T entity);
        void Delete(int id);
        void SaveChanges();
        IEnumerable<Book> GetBooks();
    }
}