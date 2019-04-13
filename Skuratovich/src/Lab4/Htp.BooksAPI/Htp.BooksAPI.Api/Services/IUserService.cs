using System;
using Htp.BooksAPI.Domain.Contracts.ViewModels;
using Microsoft.IdentityModel.Tokens;

namespace Htp.BooksAPI.Api.Services
{
    public interface IUserService
    {
        ClientModel Authenticate(string username, string password);
    }
}
