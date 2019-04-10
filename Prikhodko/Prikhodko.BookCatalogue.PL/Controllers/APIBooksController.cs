using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using Prikhodko.BookCatalogue.Service.Contracts.Models;
using Prikhodko.BookCatalogue.Service.Contracts.Interfaces;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Prikhodko.BookCatalogue.PL.Controllers
{
    //[Authenticate]
    [RoutePrefix("books")]
    public class APIBooksController : Controller
    {
        private readonly IBookService bookService;
        
        public APIBooksController(IBookService bookService, ILanguageService languageService)
        {
            this.bookService = bookService;
        }

        [Route]
        [HttpGet]
        public ActionResult GetAll()
        {
            var model = bookService.GetAll();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult Get(int id)
        {
            var model = bookService.Get(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [Route]
        [HttpPost]
        public ActionResult Add(BookViewModel bookViewModel)
        {
            if (bookViewModel == null)
            {
                throw new ArgumentNullException(nameof(bookViewModel));
            }
            if(bookViewModel.AvailableLanguages == null)
            {
                bookViewModel.AvailableLanguages = new List<string>();
            }
            bookService.Add(bookViewModel);
            return new HttpStatusCodeResult(HttpStatusCode.Created);
        }
        
        [Route("{id}")]
        [HttpPut]
        public ActionResult Update(int id, BookViewModel input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if(id < 0 || input.Id < 0 || input.Title == null || string.IsNullOrEmpty(input.Author.FirstName) || input.DateOfIssue == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (input.AvailableLanguages == null)
            {
                input.AvailableLanguages = new List<string>();
            }

            var model = bookService.Get(id);

            if (model == null)
            {
                //Add(input);
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }

            else
            {
                input.Id = model.Id;
                bookService.Update(input);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            bookService.Remove(id);
            return new HttpStatusCodeResult(HttpStatusCode.NoContent);
        }
    }
}
