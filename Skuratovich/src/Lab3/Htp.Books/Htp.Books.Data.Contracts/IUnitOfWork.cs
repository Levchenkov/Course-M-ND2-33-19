using Htp.Books.Data.Contracts.Entities;

namespace Htp.Books.Data.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<TKey, TEntity> Repository<TKey, TEntity>() where TEntity : Entity<TKey>;
    }
}
