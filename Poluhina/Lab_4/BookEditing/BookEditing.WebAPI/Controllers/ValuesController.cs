﻿using BookEditing.WebAPI.Models;
using BookEditing.WebAPI.Services;
using System.Collections.Generic;
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
            var bookApiModelList = bookService.GetList();
            return bookApiModelList;
        }

        // GET api/values/5
        public BookApiModel Get(int id)
        {
            var bookApiModel = bookService.Get(id);
            return bookApiModel;
        }

        // POST api/values
        public void Post([FromBody]BookApiModel book)
        {
            bookService.Add(book);
        }
        // PUT api/values/5
        public void Put(int id, [FromBody] BookApiModel bookApiModel)
        {
            var book = bookService.Get(id);

            book.Id = bookApiModel.Id;
            book.Created = bookApiModel.Created;
            book.CreatedBy = bookApiModel.CreatedBy;
            book.Description = bookApiModel.Description;
            book.Title = bookApiModel.Title;
            book.Updated = bookApiModel.Updated;
            book.UpdatedBy = bookApiModel.UpdatedBy;
            bookService.Change(book);
        }
        // DELETE api/values/5
        public void Delete(int id)
        {
            bookService.Remove(id);
        }
    }
}
