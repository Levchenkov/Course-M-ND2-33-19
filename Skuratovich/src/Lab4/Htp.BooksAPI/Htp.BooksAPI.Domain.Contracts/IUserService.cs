using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Htp.BooksAPI.Domain.Contracts.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Htp.BooksAPI.Domain.Contracts
{
    public interface IUserService
    {
        UserViewModel FindByName(string normalizedUserName);
        Task<UserViewModel> FindByIdAsync(string id);

        Task<IEnumerable<IdentityUserClaim<string>>> FindClaimsByIdAsync(string id);
    }
}
