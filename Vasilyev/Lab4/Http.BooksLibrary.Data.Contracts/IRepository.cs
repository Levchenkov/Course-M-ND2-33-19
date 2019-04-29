using System.Collections.Generic;

namespace Http.BooksLibrary.Data.Contracts
{
    public interface IRepository<T>
    {
        T Get(int id);
        IList<T> GetList();
        void Add(T book);
        void Change(T book);
        void Delete(int id);
        void SaveChanges();
    }
}