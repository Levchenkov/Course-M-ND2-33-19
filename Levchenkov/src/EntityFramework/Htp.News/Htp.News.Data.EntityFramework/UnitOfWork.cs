using CommonServiceLocator;
using Htp.News.Data.Contracts;

namespace Htp.News.Data.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public T Get<T>(int id) where T : class
        {
            var repository = ServiceLocator.Current.GetInstance<IRepository<T>>();
            var result = repository.Get(id);
            return result;
        }
    }
}
