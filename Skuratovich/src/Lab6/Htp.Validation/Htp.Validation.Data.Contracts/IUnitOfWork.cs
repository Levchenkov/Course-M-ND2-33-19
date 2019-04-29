using System.Threading.Tasks;

namespace Htp.Validation.Data.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : Entity;
        Task<int> SaveChangesAsync();
        ITransaction BeginTransaction();
    }
}
