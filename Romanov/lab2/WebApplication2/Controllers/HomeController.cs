using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        Repository repository = new Repository();
        JsonDb db = new JsonDb();

        public ActionResult Index()
        {
            repository = db.LoadFromJsonDbFile();
            ViewBag.Books = repository.Books;
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Book book)
        {

            if (ModelState.IsValid)
            {
                repository = db.LoadFromJsonDbFile();
                repository.AddBook(book);
                db.SaveChangesToJsonDb(repository);
                return RedirectToAction("Show", new { id = book.BookId });
            }
            return View();
        }

        public ActionResult Del(int id)
        {
            repository = db.LoadFromJsonDbFile();
            repository.DeleteBook(id);
            db.SaveChangesToJsonDb(repository);
            return RedirectToAction("Index");
        }


        public ActionResult Show(int id)
        {
            repository = db.LoadFromJsonDbFile();
            Book book = repository.GetBook(id);
            return View(book);
        }

        public ActionResult Get()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Get(Book book)
        {
            repository = db.LoadFromJsonDbFile();
            return RedirectToAction("Show", new { id = book.BookId });
        }

    }
}