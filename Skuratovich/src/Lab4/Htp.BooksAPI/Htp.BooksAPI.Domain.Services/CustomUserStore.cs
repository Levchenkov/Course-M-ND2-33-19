using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Htp.BooksAPI.Domain.Contracts;
using Htp.BooksAPI.Domain.Contracts.ViewModels;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Htp.BooksAPI.Domain.Services
{
    /// <summary>
    /// This store is only partially implemented. It supports user creation and find methods.
    /// </summary>
    public class CustomUserStore : IUserStore<UserViewModel>, IUserPasswordStore<UserViewModel>, IUserClaimStore<UserViewModel>
    {
        private readonly IToken token;

        private const string baseUri = "http://localhost:5002/api/users";

        public CustomUserStore(IToken token)
        {
            this.token = token;
        }

        public Task<IdentityResult> CreateAsync(UserViewModel user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(UserViewModel user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public async Task<UserViewModel> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userId == null) throw new ArgumentNullException(nameof(userId));
            Guid idGuid;
            if (!Guid.TryParse(userId, out idGuid))
            {
                throw new ArgumentException("Not a valid Guid id", nameof(userId));
            }
            // TODO: mapping

            await token.Initialization;

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);

            var response = await httpClient.GetAsync($"{baseUri}/{userId}", cancellationToken);

            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            var userViewModel = JsonConvert.DeserializeObject<UserViewModel>(jsonString);

            return userViewModel;
        }

        public async Task<UserViewModel> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (normalizedUserName == null) throw new ArgumentNullException(nameof(normalizedUserName));

            // TODO: mapping

            await token.Initialization;

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);

            var response = await httpClient.GetAsync($"{baseUri}/login/{normalizedUserName}", cancellationToken);

            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            var userViewModel = JsonConvert.DeserializeObject<UserViewModel>(jsonString);

            return userViewModel;
        }

        public Task<string> GetNormalizedUserNameAsync(UserViewModel user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(UserViewModel user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.PasswordHash);
        }

        public Task<string> GetUserIdAsync(UserViewModel user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(UserViewModel user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.UserName);
        }

        public Task<bool> HasPasswordAsync(UserViewModel user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(UserViewModel user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(UserViewModel user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(UserViewModel user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(UserViewModel user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Claim>> GetClaimsAsync(UserViewModel user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            // TODO: mapping

            await token.Initialization;

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);

            var response = await httpClient.GetAsync($"{baseUri}/{user.Id}/claims", cancellationToken);

            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();

            var test = JsonConvert.DeserializeObject<IList<IdentityUserClaim<string>>>(jsonString);

            var userClaims = JsonConvert.DeserializeObject<IList<Claim>>(jsonString);

            userClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

            return userClaims;
        }

        public Task AddClaimsAsync(UserViewModel user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ReplaceClaimAsync(UserViewModel user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimsAsync(UserViewModel user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserViewModel>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}