using System.Collections.Generic;

namespace Lab2.Models
{
    public interface IRepository<T>
    {
        T Get(int id);
        void Add(T entity);
        void Edit(int id, T entity);
        void Delete(int id);
        void SaveChanges();
        IList<Book> View();
    }
}