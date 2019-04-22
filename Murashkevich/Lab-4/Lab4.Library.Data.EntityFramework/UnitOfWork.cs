using System.Collections.Generic;
using Lab4.Library.Data.Contracts;
using Autofac;

namespace Lab4.Library.Data.EntityFramework
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

        public T Get<T>(int id) where T : class
        {
            var repository = GetRepository<T>();
            var result = repository.Get(id);
            return result;
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            var repository = GetRepository<T>();
            var result = repository.GetAll();
            return result;
        }

        public void Add<T>(T entity) where T : class
        {
            var repository = GetRepository<T>();
            repository.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            var repository = GetRepository<T>();
            repository.Update(entity);
        }

        public void Delete<T>(int id) where T : class
        {
            var repository = GetRepository<T>();
            repository.Delete(id);
        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var repository = _componentContext.Resolve<IRepository<T>>();
            return repository;
        }
    }
}
