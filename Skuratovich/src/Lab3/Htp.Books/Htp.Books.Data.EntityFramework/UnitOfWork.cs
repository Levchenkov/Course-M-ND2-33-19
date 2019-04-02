using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Autofac;
using Htp.Books.Data.Contracts;
using Htp.Books.Data.Contracts.Entities;

namespace Htp.Books.Data.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext dbContext;
        private readonly IComponentContext componentContext;
        //private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        //public Dictionary<Type, object> Repositories
        //{
        //    get { return repositories; }
        //    set { Repositories = value; }
        //}

        public UnitOfWork(ApplicationDbContext dbContext, IComponentContext componentContext)
        {
            this.dbContext = dbContext;
            this.componentContext = componentContext;
        }

        //public IRepository<TKey, TEntity> Repository<TKey, TEntity>() where TEntity : Entity<TKey>
        //{
        //    if (Repositories.Keys.Contains(typeof(TEntity)))
        //    {
        //        return Repositories[typeof(TEntity)] as IRepository<TKey, TEntity>;
        //    }

        //    IRepository<TKey,TEntity> repo = new Repository<TKey, TEntity>(dbContext);
        //    Repositories.Add(typeof(TEntity), repo);
        //    return repo;
        //}

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


        //public ITransaction BeginTransaction()
        //{
        //    var transaction = new Transaction(dbContext.Database.BeginTransaction());
        //    return transaction;
        //}
    }
}
