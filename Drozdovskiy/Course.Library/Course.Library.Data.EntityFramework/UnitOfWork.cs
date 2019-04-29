using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Course.Library.Data.Contracts;
using Course.Library.Data.Contracts.Entities;

namespace Course.Library.Data.EntityFramework
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

        public void Add<T>(T entity) where T : class
        {
            var repository = GetRepository<T>();
            repository.Update(entity);
        }

        public T Get<T>(int id) where T : class
        {
            var repository = GetRepository<T>();
            var result = repository.Get(id);
            return result;
        }

        public IEnumerable<Book> GetAll<T>() where T : class
        {
            var repository = GetRepository<T>();
            var result = repository.GetAll();
            return result;
        }
        public IEnumerable<Genre> GetGenres()
        {
            var repository = GetRepository<Genre>();
            var result = repository.GetGenres();
            return result;
        }

        public IEnumerable<Language> GetLanguages()
        {
            var repository = GetRepository<Language>();
            var result = repository.GetLanguages();
            return result;
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

        public ITransaction BeginTransaction()
        {
            var transaction = new Transaction(dbContext.Database.BeginTransaction());
            return transaction;
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
