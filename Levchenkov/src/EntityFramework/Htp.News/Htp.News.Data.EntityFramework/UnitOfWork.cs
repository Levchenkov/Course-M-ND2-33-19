using System.Data;
using Autofac;
using Htp.News.Data.Contracts;

namespace Htp.News.Data.EntityFramework
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

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public ITransaction BeginTransaction()
        {
            var transaction = new Transaction(dbContext.Database.BeginTransaction());
            return transaction;
        }

        public T Get<T>(int id) where T : class
        {
            var repository = GetRepository<T>();
            var result = repository.Get(id);
            return result;
        }

        private IRepository<T> GetRepository<T>() where T :class 
        {
            var repository = componentContext.Resolve<IRepository<T>>();
            return repository;
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

        public void Remove<T>(int id) where T : class
        {
            var repository = GetRepository<T>();
            repository.Remove(id);
        }
    }
}
