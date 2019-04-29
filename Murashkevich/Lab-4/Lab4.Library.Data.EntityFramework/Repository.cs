using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Lab4.Library.Data.Contracts;

namespace Lab4.Library.Data.EntityFramework
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Get(int id)
        {
            var dbSet = _dbContext.Set<T>();
            var result = dbSet.Find(id);
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            var dbSet = _dbContext.Set<T>();
            var result = dbSet.ToList();
            return result;
        }

        public void Add(T entity)
        {
            var dbSet = _dbContext.Set<T>();
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().AddOrUpdate(entity);
        }

        public void Delete(int id)
        {
            var dbSet = _dbContext.Set<T>();
            dbSet.Remove(Get(id));
        }
    }
}
