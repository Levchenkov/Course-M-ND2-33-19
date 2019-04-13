using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Htp.BooksAPI.Domain.Contracts;
using Htp.BooksAPI.Domain.Contracts.ViewModels;
using Newtonsoft.Json;

namespace Htp.BooksAPI.Domain.Services
{
    public class ApiBookService : IBookService
    {
        // TODO: Add automapper
        //private readonly IMapper mapper;
        private readonly IToken token;

        private const string baseUri = "http://localhost:5002/api/books";

        public ApiBookService(IToken token)
        {
            this.token = token;
        }

        public void Add(BookViewModel bookViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var httpClient = new HttpClient();

            await token.Initialization;

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);

            var response = await httpClient.DeleteAsync($"{baseUri}/{id}");

            response.EnsureSuccessStatusCode();

            return true;
        }

        public async Task<bool> EditAsync(BookViewModel bookViewModel)
        {
            var httpClient = new HttpClient();

            await token.Initialization;

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);

            var jsonString = JsonConvert.SerializeObject(bookViewModel);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"{baseUri}/{bookViewModel.Id}", content);

            response.EnsureSuccessStatusCode();

            return true;
        }

        public IEnumerable<BookViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookViewModel>> GetAllAsync()
        {
            var httpClient = new HttpClient();

            await token.Initialization;

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);

            var response = await httpClient.GetAsync($"{baseUri}");

            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IEnumerable<BookViewModel>>(jsonString);

            return result;
        }

        public async Task<BookViewModel> GetAsync(int id)
        {
            var httpClient = new HttpClient();

            await token.Initialization;

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);

            var response = await httpClient.GetAsync($"{baseUri}/{id}");

            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BookViewModel>(jsonString);

            return result;
        }

        public async Task<BookViewModel> AddAsync(BookViewModel bookViewModel)
        {
            var httpClient = new HttpClient();

            await token.Initialization;

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);

            var jsonString = JsonConvert.SerializeObject(bookViewModel);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{baseUri}", content);

            response.EnsureSuccessStatusCode();
            jsonString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BookViewModel>(jsonString);

            return result;
        }
    }
}
