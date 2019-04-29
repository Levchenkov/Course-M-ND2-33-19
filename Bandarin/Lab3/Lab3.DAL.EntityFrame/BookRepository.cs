using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab3.DAL.Contracts;
using Lab3.DAL.Contracts.Entities;
using System.Threading.Tasks;

namespace Lab3.DAL.EntityFrame
{
    public class Repository<T> : IRepository<T> where T:class
    {
        private readonly BookContext dbContext;

        public Repository (BookContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(T book)
        {
            var dbSet = dbContext.Set<T>();
            dbSet.Add(book);
            
        }

        public T Get(int id)
        {
            var dbSet = dbContext.Set<T>();
            var result = dbSet.Find(id);
            return result;
        }

        public void Remove(int id)
        {
            var dbSet = dbContext.Set<T>();
            var book = dbSet.Find(id);
            dbSet.Remove(book);
            
        }

        public void Update(T book)
        {
           
        }

       

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
