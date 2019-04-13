using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Htp.BooksAPI.Data.Contracts
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> FindAsync(params object[] keyValues);
        TEntity Get(int id);
        TEntity Get(string id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Save();
    }
}
