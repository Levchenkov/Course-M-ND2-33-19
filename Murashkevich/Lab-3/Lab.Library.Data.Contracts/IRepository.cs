using System.Collections.Generic;

namespace Lab.Library.Data.Contracts
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
        void SaveChange();
    }
}
