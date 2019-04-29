using System.Collections.Generic;

namespace Lab.Library.Data.Contracts
{
    public interface IUnitOfWork
    {
        void SaveChange();
        ITransaction BeginTransaction();

        T Get<T>(int id) where T : class;
        void Add<T>(T entity) where T : class;
        void Remove<T>(int id) where T : class;
        void Update<T>(T entity) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;
    }
}
