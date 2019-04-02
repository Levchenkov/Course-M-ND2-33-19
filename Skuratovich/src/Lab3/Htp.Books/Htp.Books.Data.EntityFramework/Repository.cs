using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Htp.Books.Data.Contracts;
using Htp.Books.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Htp.Books.Data.EntityFramework
{
    // TODO: Check Entity
    //public class Repository<TKey, TEntity> : IRepository<TKey, TEntity> where TEntity : IEntity<TKey>
    //public class Repository<TKey, TEntity> : IRepository<TKey, TEntity> where TEntity : class
    public class Repository<TKey, TEntity> : IRepository<TKey, TEntity> where TEntity : Entity<TKey>
    {
        private readonly ApplicationDbContext dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        public TEntity Get(TKey id)
        {
            var dbSet = dbContext.Set<TEntity>();
            var result = dbSet.Find(id);
            return result;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.Set<TEntity>().Update(entity);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return dbContext.Set<TEntity>().Where(expression);
        }

        public void Test(TEntity entity)
        {
            var dbSet = dbContext.Set<Book>();
            var book = dbSet.Find(entity.Id);
            book.Description = "Test - test";
            dbContext.SaveChanges(); 
            //dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
