using System.Collections.Generic;

namespace Htp.Library.Data.Contracts
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();

        void Add(T entity);
        void Edit(int id, T entity);
        void Remove(int id);

        void SaveChanges();
    }
}