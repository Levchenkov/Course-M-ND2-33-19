using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab4.Library.Domain.Contracts;
using Lab4.Library.Domain.Contracts.ViewModel;
using Microsoft.AspNet.Identity;

namespace Lab4.Library.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: Book
        public ActionResult Show()
        {
            var books = _bookService.GetAll();
            return View(books);
        }

        [Authorize]
        public ActionResult Create()
        {
            BookViewModel book = new BookViewModel
            {
                Title = "New Title",
                Description = "New Description",
            };
            return View(book);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(BookViewModel model)
        {
            model.CreatedBy = User.Identity.GetUserName();
            model.Create = DateTime.Now;
            _bookService.Add(model);
            return RedirectToAction("Show");
        }

        [Authorize]
        public ActionResult Update(int id)
        {
            var book = _bookService.Get(id);
            return View(book);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Update(BookViewModel book)
        {
            book.UpdatedBy = User.Identity.GetUserName();
            book.Updated = DateTime.Now;
            book.CreatedBy = _bookService.Get(book.Id).CreatedBy;
            book.Create = _bookService.Get(book.Id).Create;
            _bookService.Update(book);
            return RedirectToAction("Show");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return RedirectToAction("Show");
        }
    }
}