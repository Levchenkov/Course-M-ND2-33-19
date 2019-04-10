using System.Collections.Generic;
using Autofac;
using Htp.Library.Data.Contracts;
using Htp.Library.Data.Contracts.Entities;

namespace Htp.Library.Data.EntityFramework
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

        public ITransaction BeginTransaction()
        {
            var transaction = new Transaction(dbContext.Database.BeginTransaction());
            return transaction;
        }

        public T Get<T>(int id) where T : class
        {
            var repository = GetRepository<T>();
            return repository.Get(id);
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            var repository = GetRepository<T>();
            return repository.GetAll();
        }

        public void Add<T>(T entity) where T : class
        {
            var repository = GetRepository<T>();
            repository.Add(entity);
        }

        public void Edit<T>(int id, T entity) where T : class
        {
            var repository = GetRepository<T>();
            repository.Edit(id, entity);
        }

        public void Remove<T>(int id) where T : class
        {
            var repository = GetRepository<T>();
            repository.Remove(id);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var repository = componentContext.Resolve<IRepository<T>>();
            return repository;
        }
    }
}