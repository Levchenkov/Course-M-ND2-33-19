using System;
using System.Collections.Generic;
using Prikhodko.BookCatalogue.FrontEnd.Models;
using Prikhodko.BookCatalogue.FrontEnd.Services.Contracts;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Prikhodko.BookCatalogue.FrontEnd.Services
{
    public class FrontEndBookService : IFrontEndBookService
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string externalResourceLink = "http://localhost:50597";

        public async Task<bool> Add(BookViewModel item)
        {
            if (item == null)
            {
                return false;
            }
            var json = JsonConvert.SerializeObject(item);
            var taskResult = await httpClient.PostAsync($"{externalResourceLink}/books", new StringContent(json, Encoding.UTF8, "application/json"));
            return taskResult.IsSuccessStatusCode;
        }

        public async Task<BookViewModel> Get(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            var httpResult = await httpClient.GetAsync($"{externalResourceLink}/books/{id}");
            BookViewModel bookViewModel =
                JsonConvert.DeserializeObject<BookViewModel>(await httpResult.Content.ReadAsStringAsync());
            return bookViewModel;
        }

        public async Task<IEnumerable<BookViewModel>> GetAll()
        {
            var httpResult = await httpClient.GetAsync($"{externalResourceLink}/books");
            var bookViewModels = JsonConvert.DeserializeObject<List<BookViewModel>>(await httpResult.Content.ReadAsStringAsync());
            return bookViewModels;
        }

        public async Task<bool> Remove(int id)
        {
            if (id <= 0)
            {
                return false;
            }
            var httpResult = await httpClient.DeleteAsync($"{externalResourceLink}/books/{id}");
            return httpResult.IsSuccessStatusCode;
        }

        public async Task<bool> Update(BookViewModel item)
        {
            if (item == null)
            {
                return false;
            }
            var json = JsonConvert.SerializeObject(item);
            var httpResult = await httpClient.PutAsync($"{externalResourceLink}/books/{item.Id}", new StringContent(json, Encoding.UTF8, "application/json"));
            return httpResult.IsSuccessStatusCode;
        }
    }
}