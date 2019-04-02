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
        JsonDb Db = new JsonDb();

        public ActionResult Index()
        {
            repository = Db.LoadFromJsonDbFile();
            ViewBag.Books = repository.Books;
            return View();
        }
        
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult Add(Book book)
        {
            repository = Db.LoadFromJsonDbFile();
            repository.AddBook(book);
            Db.SaveChangesToJsonDb(repository);
            return RedirectToAction("Show", new { id = repository.GetBookId(book) });
        }

        public ActionResult Del()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Del(Book book)
        {
            repository = Db.LoadFromJsonDbFile();
            repository.DelBook(book.BookId);
            Db.SaveChangesToJsonDb(repository);
            return RedirectToAction("Index");
        }
        
        public ActionResult Show(int id)
        {
            repository = Db.LoadFromJsonDbFile();
            Book book = repository.GetBookById(id);
            return View(book);
        }

        public ActionResult Get()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult Get(Book book)
        {
            repository = Db.LoadFromJsonDbFile();
            int BookId = repository.GetBookId(book);
            return RedirectToAction("Show", new { id = BookId });
        }
        
    }
}