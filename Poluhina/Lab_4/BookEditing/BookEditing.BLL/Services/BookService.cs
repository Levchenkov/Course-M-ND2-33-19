using AutoMapper;
using BookEditing.BLL.DTO;
using BookEditing.BLL.Interfaces;
using BookEditing.DAL.Entities;
using BookEditing.DAL.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace BookEditing.BLL.Services
{
    public class BookService : IBookService<BookDTO>
    {
        private HttpClient client;
        public BookService()
        {
            client = new HttpClient();
        }
        public void Add(BookDTO item)
        {
           
            

            throw new System.NotImplementedException();
        }

        public void Change(BookDTO item)
        {
            //вызвать метод api
        }

        public BookDTO Get(int id)
        {
            throw new System.NotImplementedException();
            //вызвать метод api
        }

        public IEnumerable<BookDTO> GetList()
        {
            client = new HttpClient();
            var responce = client.GetAsync("http://localhost:32230/api/values")
                 .ConfigureAwait(false)
                 .GetAwaiter()
                 .GetResult();
            var stringContext = responce.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            var bookDTOList =JsonConvert.DeserializeObject<List<BookDTO>>(stringContext);
            return bookDTOList;
            //десериализовать!!!!
        }

        public void Remove(int id)
        {
            //вызвать метод api
        }
    }
}
