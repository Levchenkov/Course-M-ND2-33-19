using Htp.Books.Data.Contracts.Entities;

namespace Htp.Books.Data.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<TKey, TEntity> Repository<TKey, TEntity>() where TEntity : Entity<TKey>;

        void SaveChanges();
        //ITransaction BeginTransaction();

        TEntity Get<TEntity>(int id) where TEntity : Entity<int>;
        void Add<TEntity>(TEntity entity) where TEntity : Entity<int>;
        void Remove<TEntity>(int id) where TEntity : Entity<int>;


    }
}
