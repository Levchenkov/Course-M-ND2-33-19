using System;
using System.Collections.Generic;
using System.Linq;
using Htp.Books.Data.Contracts;
using Htp.Books.Data.Contracts.Entities;

namespace Htp.Books.Data.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext dbContext;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public Dictionary<Type, object> Repositories
        {
            get { return repositories; }
            set { Repositories = value; }
        }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IRepository<TKey, TEntity> Repository<TKey, TEntity>() where TEntity : Entity<TKey>
        {
            if (Repositories.Keys.Contains(typeof(TEntity)))
            {
                return Repositories[typeof(TEntity)] as IRepository<TKey, TEntity>;
            }

            IRepository<TKey,TEntity> repo = new Repository<TKey, TEntity>(dbContext);
            Repositories.Add(typeof(TEntity), repo);
            return repo;
        }
    }
}
