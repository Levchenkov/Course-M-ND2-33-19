using Htp.Library.Data.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Htp.Library.Data.EntityFramework
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T Get(int id)
        {
            var dbSet = dbContext.Set<T>();
            var result = dbSet.Find(id);
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            var dbSet = dbContext.Set<T>();
            var rez = dbSet.ToList();
            return rez;
        }

        public void Add(T entity)
        {
            var dbSet = dbContext.Set<T>();
            dbSet.Add(entity);
        }

        public void Edit(int id, T entity)
        {
            var dbSet = dbContext.Set<T>();
            var change_entity = dbSet.Find(id);
            dbSet.Remove(change_entity);
            dbSet.Add(entity);
        }

        public void Remove(int id)
        {
            var dbSet = dbContext.Set<T>();
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}