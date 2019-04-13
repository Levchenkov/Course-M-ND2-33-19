using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Htp.BooksAPI.Data.Contracts;
using Htp.BooksAPI.Data.Contracts.Entities;
using Htp.BooksAPI.Domain.Contracts;
using Htp.BooksAPI.Domain.Contracts.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Htp.BooksAPI.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public UserViewModel FindByName(string normalizedUserName)
        {
            //var user = await unitOfWork.Repository<AppUser>().FindAsync(new KeyValuePair<string, string>("NormalizedUserName", normalizedUserName));
            var users = (List<AppUser>)unitOfWork.Repository<AppUser>().FindByCondition(x => x.NormalizedUserName == normalizedUserName);

            if ((users == null) || (users.Count == 0))
            {
                return null;
            }
            ////TODO: create DTO?
            var userViewModel = mapper.Map<UserViewModel>(users[0]);

            return userViewModel;
        }

        public async Task<UserViewModel> FindByIdAsync(string id)
        {
            AppUser user = await unitOfWork.Repository<AppUser>().FindAsync(id);
            var userViewModel = mapper.Map<UserViewModel>(user);
            return userViewModel; 
        }

        public async Task<IEnumerable<IdentityUserClaim<string>>> FindClaimsByIdAsync(string id)
        {
            var user = await unitOfWork.AppUserRepository.GetAsync(id);

            return user.Claims;
        }
    }
}
