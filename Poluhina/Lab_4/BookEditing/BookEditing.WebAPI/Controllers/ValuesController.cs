using BookEditing.DAL.Entities;
using BookEditing.WebAPI.Models;
using BookEditing.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace BookEditing.WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IBookService bookService;

        public ValuesController()
        {
            bookService = DependencyResolver.Current.GetService<IBookService>();
        }

        // GET api/values
        public IEnumerable<BookApiModel> Get()
        {
            var bookList=bookService.GetList();
            return bookList;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
