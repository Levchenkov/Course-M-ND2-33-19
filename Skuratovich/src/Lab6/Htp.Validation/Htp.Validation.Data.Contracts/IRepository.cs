using System.Collections.Generic;
using System.Threading.Tasks;

namespace Htp.Validation.Data.Contracts
{
    public interface IRepository<TEntity>
    {
        bool EntityExists(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
    }
}
