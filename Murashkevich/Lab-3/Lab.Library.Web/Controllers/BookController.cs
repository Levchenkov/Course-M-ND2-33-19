using System.Web.Mvc;
using Lab.Library.Domain.Contracts;
using Lab.Library.Domain.Contracts.ViewModels;

namespace Lab.Library.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public ActionResult Add()
        {
            BookViewModel book = new BookViewModel();
            return View(book);
        }

        [HttpPost]
        public ActionResult Add(BookViewModel viewModel)
        {
            _bookService.Add(viewModel);
            return RedirectToAction("Show");
        }

        public ActionResult Show()
        {
            var books = _bookService.GetAll();
            return View(books);
        }

        public ActionResult Remove(int id)
        {
            _bookService.Remove(id);
            return RedirectToAction("Show");
        }

        public ActionResult Update(int id)
        {
            var viewModel = _bookService.Get(id);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Update(BookViewModel viewModel)
        {
            _bookService.Update(viewModel);
            return RedirectToAction("Show");
        }
    }
}