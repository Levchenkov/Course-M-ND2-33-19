using System.Threading.Tasks;
using Htp.BooksAPI.Data.Contracts.Entities;

namespace Htp.BooksAPI.Data.Contracts
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        Task<AppUser> GetAsync(string id);
    }
}
