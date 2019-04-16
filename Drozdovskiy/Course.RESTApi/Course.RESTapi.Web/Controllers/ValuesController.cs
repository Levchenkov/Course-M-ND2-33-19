using Course.RESTapi.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Course.RESTapi.Domain.Contracts.ViewModels;
using Newtonsoft.Json;

namespace Course.RESTapi.Web.Controllers
{

    public class ValuesController : ApiController
    {
        private readonly IBookService bookService;

        public ValuesController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        // GET api/values
        public string Get()
        {
            var viewModel = JsonConvert.SerializeObject(bookService.GetAll());
            return viewModel;
        }

        // GET api/values/5
        public string Get(int id)
        {
            var viewModel = bookService.Get(id);
            var result = JsonConvert.SerializeObject(viewModel);
            return result;
        }

        // POST api/values
        public void Post(dynamic tempValue)
        {
            var value = JsonConvert.SerializeObject(tempValue);
            var viewModel = JsonConvert.DeserializeObject<BookViewModel>(value);
            bookService.Save(viewModel);
        }

        // PUT api/values/5
        public void Put(int id, dynamic tempValue)
        {
            var value = JsonConvert.SerializeObject(tempValue);
            var viewModel = bookService.Get(id);
            viewModel = JsonConvert.DeserializeObject<BookViewModel>(value);
            bookService.Save(viewModel);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            bookService.Delete(id);
        }
    }
}
