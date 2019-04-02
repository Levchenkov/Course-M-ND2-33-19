using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Autofac;
using Htp.Books.Data.Contracts;

namespace Htp.Books.Data.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IComponentContext componentContext;

        public UnitOfWork(ApplicationDbContext dbContext, IComponentContext componentContext)
        {
            this.dbContext = dbContext;
            this.componentContext = componentContext;
        }

        private IRepository<TKey, TEntity> GetRepository<TKey, TEntity>()
        {
            var repository = componentContext.Resolve<IRepository<TKey, TEntity>>();
            return repository;
        }

        public IEnumerable<TEntity> GetAll<TKey, TEntity>()
        {
            var repository = GetRepository<TKey, TEntity>();
            var result = repository.GetAll();
            return result;
        }

        public IEnumerable<TEntity> FindByCondition<TKey, TEntity>(Expression<Func<TEntity, bool>> expression)
        {
            var repository = GetRepository<TKey, TEntity>();
            var result = repository.FindByCondition(expression);
            return result;
        }

        public TEntity Get<TKey, TEntity>(TKey id)
        {
            var repository = GetRepository<TKey, TEntity>();
            var result = repository.Get(id);
            return result;
        }

        public void Add<TKey, TEntity>(TEntity entity)
        {
            var repository = GetRepository<TKey, TEntity>();
            repository.Add(entity);
        }

        public void Update<TKey, TEntity>(TEntity entity)
        {
            var repository = GetRepository<TKey, TEntity>();
            repository.Update(entity);
        }

        public void Delete<TKey, TEntity>(TEntity entity)
        {
            var repository = GetRepository<TKey, TEntity>();
            repository.Delete(entity);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public ITransaction BeginTransaction()
        {
            var transaction = new Transaction(dbContext.Database.BeginTransaction());
            return transaction;
        }
    }
}
