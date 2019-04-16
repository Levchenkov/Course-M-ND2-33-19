using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Lab.Library.Data.Contracts;

namespace Lab.Library.Data.EntityFramework
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

        public void Remove(int id)
        {
            var dbSet = _dbContext.Set<T>();
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }
    }
}
