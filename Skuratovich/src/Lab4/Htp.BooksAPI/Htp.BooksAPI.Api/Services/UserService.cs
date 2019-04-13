using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Htp.BooksAPI.Api.Helpers;
using Htp.BooksAPI.Domain.Contracts.ViewModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Htp.BooksAPI.Api.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings appSettings;

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<ClientModel> clients = new List<ClientModel>
        {
            new ClientModel { Id = 55, Username = "user", Password = "password"}
        };

        public UserService(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

        public ClientModel Authenticate(string username, string password)
        {
            var client = clients.SingleOrDefault(x => x.Username == username && x.Password == password);

            if (client == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            var secretKey = new SymmetricSecurityKey(key);
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Subject = new ClaimsIdentity(new Claim[]
                //{
                //    new Claim(ClaimTypes.Name, client.Id.ToString())
                //}),
                Issuer = "http://localhost:5002",
                Audience = "http://localhost:5003",
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = signinCredentials
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            client.Token = tokenHandler.WriteToken(securityToken);

            client.Password = null;

            return client;
        }
    }
}
