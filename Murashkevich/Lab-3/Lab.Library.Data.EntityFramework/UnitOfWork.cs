using System.Collections.Generic;
using Autofac;
using Lab.Library.Data.Contracts;

namespace Lab.Library.Data.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IComponentContext _componentContext;

        public UnitOfWork(ApplicationDbContext dbContext, IComponentContext componentContext)
        {
            _dbContext = dbContext;
            _componentContext = componentContext;
        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }

        public ITransaction BeginTransaction()
        {
            var transaction = new Transaction(_dbContext.Database.BeginTransaction());
            return transaction;
        }

        public T Get<T>(int id) where T : class
        {
            var repository = GetRepository<T>();
            var result = repository.Get(id);
            return result;
        }

        public void Add<T>(T entity) where T : class
        {
            var repository = GetRepository<T>();
            repository.Add(entity);
        }

        public void Remove<T>(int id) where T : class
        {
            var repository = GetRepository<T>();
            repository.Remove(id);
        }

        public void Update<T>(T entity) where T : class
        {
            var repository = GetRepository<T>();
            repository.Update(entity);
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            var repository = GetRepository<T>();
            var result = repository.GetAll();
            return result;
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var repository = _componentContext.Resolve<IRepository<T>>();
            return repository;
        }
    }
}
