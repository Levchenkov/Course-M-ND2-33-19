using AutoMapper;
using BookEditing.BLL.DTO;
using BookEditing.BLL.Interfaces;
using BookEditing.WebAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;

namespace BookEditing.BLL.Services
{
    public class BookService : IBookService<BookDTO>
    {
        private HttpClient client;
        public BookService()
        {
            client = new HttpClient();
        }
        [HttpPost]
        public void Add(BookDTO book)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookApiModel>()).CreateMapper();
            var bookApiModel = mapper.Map<BookDTO, BookApiModel>(book);
            var ser = JsonConvert.SerializeObject(bookApiModel);
            var content = new StringContent(ser, Encoding.UTF8, "application/json");
            var responce = client.PostAsync("http://localhost:32230/api/values", content).
                ConfigureAwait(false).
                GetAwaiter().
                GetResult();
            
        }
        public void Change(BookDTO book)
        {
            int id = book.Id;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookApiModel>()).CreateMapper();
            var bookApiModel = mapper.Map<BookDTO, BookApiModel>(book);
            var putStrContent = new StringContent(JsonConvert.SerializeObject(bookApiModel), Encoding.UTF8, "application/json");
            var responce = client.PutAsync($"http://localhost:32230/api/values/{id}", putStrContent)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }

        public BookDTO Get(int id)
        {
            var responce = client.GetAsync("http://localhost:32230/api/values/{id}")
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
            var stringContext = responce.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            var bookDTO = JsonConvert.DeserializeObject<BookDTO>(stringContext);
            return bookDTO;
        }

        public IEnumerable<BookDTO> GetList()
        {
            var responce = client.GetAsync("http://localhost:32230/api/values")
                 .ConfigureAwait(false)
                 .GetAwaiter()
                 .GetResult();
            var stringContext = responce.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            var bookDTOList =JsonConvert.DeserializeObject<List<BookDTO>>(stringContext);
            return bookDTOList;
        }

        public void Remove(int id)
        {
            client.DeleteAsync($"http://localhost:32230/api/values/{id}")
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }
    }
}
