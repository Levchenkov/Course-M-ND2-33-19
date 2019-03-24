using LibraryEditor.Models;
using System.Web.Mvc;

namespace LibraryEditor.Controllers
{
    public class HomeController : Controller
    {
        BookRepository bookRepository = new BookRepository(new JsonFileHandler());

        public ActionResult Index()
        {
            ViewBag.Books =  bookRepository.Data;
            return View(bookRepository.Data);
        }

        public ActionResult Delete(int id)
        {
            bookRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Book = bookRepository.Get(id);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            bookRepository.Edit(book);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Book book)
        {
            bookRepository.Add(book);
            return RedirectToAction("Index");
        }
    }
}