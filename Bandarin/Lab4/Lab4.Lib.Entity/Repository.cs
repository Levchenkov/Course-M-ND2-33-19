using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Lib.Entity
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BookAppContext dbContext;

        public Repository(BookAppContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T Get(int id)
        {
            var dbSet = dbContext.Set<T>();
            var result = dbSet.Find(id);
            return result;
        }

        public void Add(T entity)
        {
            var dbSet = dbContext.Set<T>();
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {

            
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
