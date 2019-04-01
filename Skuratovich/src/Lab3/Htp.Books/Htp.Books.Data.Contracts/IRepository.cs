using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Htp.Books.Data.Contracts
{
    public interface IRepository<TKey, TEntity>
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
        TEntity Get(TKey id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Save();
    }
}