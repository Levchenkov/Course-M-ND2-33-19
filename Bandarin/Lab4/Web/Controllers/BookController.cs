using Lab4.BLL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display(int id)
        {
            var book = bookService.Get(id);          
           

            return View(book);
        }

        public ActionResult Add()
        {
            var book = new BookViewModel();
            return View(book);

        }

        [HttpPost]
        public ActionResult Add(BookViewModel viewModel)
        {
            viewModel.IsCreated = DateTime.Now;
            viewModel.Updated = viewModel.IsCreated;
            viewModel.CreatedUserName = User.Identity.GetUserName();
            bookService.Add(viewModel);
            

            return RedirectToAction("Display", new { id = viewModel.Id });
        }

        public ActionResult Edit(int id)
        {
            var book = bookService.Get(id);
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit (BookViewModel viewModel)
        {
            viewModel.Updated = DateTime.Now;
            viewModel.UpdatedUserName = User.Identity.GetUserName();
            bookService.Update(viewModel);
            return RedirectToAction("Display", new { id = viewModel.Id });
        }

        public ActionResult Remove (int id)
        {
            var book = bookService.Get(id);
            return View(book);
        }

        [HttpPost]
        public ActionResult Remove(BookViewModel viewModel)
        {
            bookService.Delete(viewModel);
            return RedirectToAction("Display", new { id = viewModel.Id });
        }
    }
}