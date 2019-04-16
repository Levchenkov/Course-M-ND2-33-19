using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using Course.Client;

namespace Course.FrontendPart.Models
{
    public class BookService : IBookService
    {
        public void Delete(int id)
        {
            var client = new HttpClient();
            var responseDelete = client.DeleteAsync("http://localhost:4216/api/Values/" + id).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public BookViewModel Get(int id)
        {
            var client = new HttpClient();
            var responseGet = client.GetAsync("http://localhost:4216/api/Values/" + id).ConfigureAwait(false).GetAwaiter().GetResult();
            var content = responseGet.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            content = content.TrimStart('\"');
            content = content.TrimEnd('\"');
            content = content.Replace("\\", "");
            var result = JsonConvert.DeserializeObject<BookViewModel>(content);
            return result;
        }

        public IEnumerable<BookViewModel> GetAll() 
        {
            var client = new HttpClient();
            var responseGetAll = client.GetAsync("http://localhost:4216/api/Values").ConfigureAwait(false).GetAwaiter().GetResult();
            var content = responseGetAll.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            content = content.TrimStart('\"');
            content = content.TrimEnd('\"');
            content= content.Replace("\\", "");
            var result = JsonConvert.DeserializeObject<List<BookViewModel>>(content);
            return result;
        }

        public void Post(BookViewModel viewModel)
        {
            viewModel.Created = DateTime.Now;
            viewModel.Updated = viewModel.Created;
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(viewModel);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var responsePost = client.PostAsync("http://localhost:4216/api/Values", content).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public void Put(BookViewModel viewModel, int id)
        {
            viewModel.Updated = DateTime.Now;
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(viewModel);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var responsePut = client.PutAsync("http://localhost:4216/api/Values/"+id, content).ConfigureAwait(false).GetAwaiter().GetResult();
        }

    }
}