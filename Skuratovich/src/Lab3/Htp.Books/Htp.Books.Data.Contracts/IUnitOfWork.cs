using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Htp.Books.Data.Contracts
{
    public interface IUnitOfWork
    {
        IEnumerable<TEntity> GetAll<TKey, TEntity>();
        IEnumerable<TEntity> FindByCondition<TKey, TEntity>(Expression<Func<TEntity, bool>> expression);

        TEntity Get<Tkey, TEntity>(Tkey id);
        void Add<TKey, TEntity>(TEntity entity);
        void Update<TKey, TEntity>(TEntity entity);
        void Delete<Tkey, TEntity>(TEntity entity);

        void SaveChanges();
        ITransaction BeginTransaction();
    }
}
