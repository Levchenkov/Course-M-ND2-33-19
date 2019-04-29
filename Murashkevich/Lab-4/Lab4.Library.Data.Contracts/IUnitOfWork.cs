using System.Collections.Generic;

namespace Lab4.Library.Data.Contracts
{
    public interface IUnitOfWork
    {
        T Get<T>(int id) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(int id) where T : class;
        void SaveChange();
    }
}
