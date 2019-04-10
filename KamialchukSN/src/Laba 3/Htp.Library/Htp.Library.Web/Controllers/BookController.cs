using System.Web.Mvc;
using Htp.Library.Domain.Contracts;
using Htp.Library.Domain.Contracts.ViewModels;

namespace Htp.Library.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public ActionResult Display()
        {
            var viewModel = bookService.GetAll();
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BookViewModel book)
        {
            bookService.Add(book);
            return RedirectToAction("Display");
        }

        public ActionResult Edit(int id)
        {
            var post = bookService.Get(id);
            post.Id = id;

            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(BookViewModel book)
        {
            bookService.Edit(book.Id, book);
            return RedirectToAction("Display");
        }

        public ActionResult Delete(int id)
        {
            bookService.Delete(id);
            return RedirectToAction("Display");
        }
    }
}