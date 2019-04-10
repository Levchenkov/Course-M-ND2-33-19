using System.Collections.Generic;

namespace Htp.Library.Data.Contracts
{
    public interface IUnitOfWork
    {
        T Get<T>(int id) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;

        void Add<T>(T entity) where T : class;
        void Edit<T>(int id, T entity) where T : class;
        void Remove<T>(int id) where T : class;

        void SaveChanges();
        ITransaction BeginTransaction();
    }
}