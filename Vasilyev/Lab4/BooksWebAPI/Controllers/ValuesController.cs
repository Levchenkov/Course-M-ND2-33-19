using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Http.BooksLibrary.Data.Contracts.Entities;
using Http.BooksLibrary.Data.EntityFramework;
using Http.BooksLibrary.Domain.Contracts;
using Http.BooksLibrary.Domain.Services;

namespace BooksWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IPostService postService;
        // GET api/values
        public IEnumerable<Book> Get()
        {
            var books = postService.GetAll();
            return books as IEnumerable<Book>;
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
