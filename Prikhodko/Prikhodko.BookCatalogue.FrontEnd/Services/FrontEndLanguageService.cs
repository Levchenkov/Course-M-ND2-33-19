using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using Prikhodko.BookCatalogue.FrontEnd.Models;
using Prikhodko.BookCatalogue.FrontEnd.Services.Contracts;

namespace Prikhodko.BookCatalogue.FrontEnd.Services
{
    public class FrontEndLanguageService : IFrontEndLanguageService
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string externalResourceLink = "http://localhost:50597/";

        [Authorize(Roles = "Admin")]
        public async Task<bool> Add(LanguageViewModel item)
        {
            if (item == null)
            {
                return false;
            }
            var json = JsonConvert.SerializeObject(item);
            var taskResult = await httpClient.PostAsync($"{externalResourceLink}/languages", new StringContent(json, Encoding.UTF8, "application/json"));
            return taskResult.IsSuccessStatusCode;
        }

        public async Task<LanguageViewModel> Get(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            var httpResult = await httpClient.GetAsync($"{externalResourceLink}/languages/{id}");
            LanguageViewModel languageViewModel =
                JsonConvert.DeserializeObject<LanguageViewModel>(await httpResult.Content.ReadAsStringAsync());
            return languageViewModel;
        }

        public async Task<IEnumerable<LanguageViewModel>> GetAll()
        {
            var httpResult = await httpClient.GetAsync($"{externalResourceLink}/languages");
            var languageViewModelsViewModels = JsonConvert.DeserializeObject<List<LanguageViewModel>>(await httpResult.Content.ReadAsStringAsync());
            return languageViewModelsViewModels;
        }

        [Authorize(Roles = "Admin")]
        public async Task<bool> Update(LanguageViewModel item)
        {
            if (item == null)
            {
                return false;
            }
            var json = JsonConvert.SerializeObject(item);
            var httpResult = await httpClient.PutAsync($"{externalResourceLink}/languages/{item.LanguageId}", new StringContent(json, Encoding.UTF8, "application/json"));
            return httpResult.IsSuccessStatusCode;
        }

        [Authorize(Roles = "Admin")]
        public async Task<bool> Remove(int id)
        {
            if (id <= 0)
            {
                return false;
            }
            var httpResult = await httpClient.DeleteAsync($"{externalResourceLink}/languages/{id}");
            return httpResult.IsSuccessStatusCode;
        }

    }
}