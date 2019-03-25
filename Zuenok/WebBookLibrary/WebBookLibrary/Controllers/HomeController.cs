using System;
using System.Linq;
using System.Web.Mvc;
using WebBookLibrary.Models.LibraryModels;

namespace WebBookLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Book> bookRepository =
            new BookRepository(new JsonFileHandler());

        public ActionResult Index()
        {
            ViewBag.Books = bookRepository.GetBooks();
            var books = bookRepository.GetBooks().ToList();

            return View(books);
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
            bookRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Book = bookRepository.Get(id);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            bookRepository.Edit(book);
            bookRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var book =
                bookRepository.GetBooks().FirstOrDefault(x => x.Id == id);
            if (book == null) throw new Exception("Book not found.");

            bookRepository.Delete(id);
            bookRepository.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}