using Autofac;
using Lab3.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL.EntityFrame
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly BookContext dbContext;
        private readonly IComponentContext componentContext;

        public UnitOfWork(BookContext dbContext, IComponentContext componentContext)
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

        private IRepository<T> GetRepository<T>() where T : class
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
