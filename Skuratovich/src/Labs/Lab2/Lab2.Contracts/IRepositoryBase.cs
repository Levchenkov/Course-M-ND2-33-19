using System;
using System.Collections.Generic;

namespace Lab2.Contracts
{
    public interface IRepositoryBase<T>
    {
        T FirstOrDefault(Func<T, bool> predicate);
        IEnumerable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}