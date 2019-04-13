using System;
using System.Threading.Tasks;
using Htp.BooksAPI.Data.Contracts;
using Htp.BooksAPI.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Htp.BooksAPI.Data.EntityFramework
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<AppUser> GetAsync(string id)
        {
            var user = await DbContext.Users.SingleAsync(x => x.Id == id);

            await DbContext.Entry(user)
                .Collection(u => u.Claims)
                .LoadAsync();
                
            return user;
        }
    }
}
