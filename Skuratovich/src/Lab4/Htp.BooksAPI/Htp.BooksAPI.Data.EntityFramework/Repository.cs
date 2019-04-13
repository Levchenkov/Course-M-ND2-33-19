using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Htp.BooksAPI.Data.Contracts;
using Htp.BooksAPI.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Htp.BooksAPI.Data.EntityFramework
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected ApplicationDbContext DbContext { get; set; }

        public Repository(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
        }

        public TEntity Get(int id)
        {
            var dbSet = DbContext.Set<TEntity>();
            var result = dbSet.Find(id);
            return result;
        }

        public TEntity Get(string id)
        {
            var dbSet = DbContext.Set<TEntity>();
            var result = dbSet.Find(id);
            return result;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
            //dbContext.Entry(entity).State = EntityState.Modified;
            DbContext.Set<TEntity>().Update(entity);
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

        public IEnumerable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return DbContext.Set<TEntity>().Where(expression).ToList();
        }

        public Task<TEntity> FindAsync(params object[] keyValues)
        {
            return DbContext.Set<TEntity>().FindAsync(keyValues);
        }

    }
}
