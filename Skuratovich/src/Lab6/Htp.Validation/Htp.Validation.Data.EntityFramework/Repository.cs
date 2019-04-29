using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Htp.Validation.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Htp.Validation.Data.EntityFramework
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected ApplicationDbContext dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool EntityExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var dbSet = dbContext.Set<TEntity>();
            var result = await dbSet.ToListAsync();
            return result;
        }

        public async Task<TEntity> GetAsync(int id)
        {
            var dbSet = dbContext.Set<TEntity>();
            var result = await dbSet.FindAsync(id);
            return result;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var dbSet = dbContext.Set<TEntity>();
            await dbSet.AddAsync(entity);
            return entity; 
        }
    }
}
