using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab2.Models;

namespace lab2.Controllers
{
    
    public class HomeController : Controller
    {
        private JsonFile jfile = new JsonFile();
        private Catalog Catalog { get; set; }

        private void InitializationBooks() => Catalog = jfile.Load();
        public ActionResult Index(int id)
        {
            InitializationBooks();
            ViewBag.Book = Catalog.Books;
            return View(ViewBag.Book[id]);
        }

        public ActionResult Add()
        {
            InitializationBooks();
            ViewBag.Books = Catalog.Books.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Add(Book book)
        {
            InitializationBooks();
            Catalog.Add(book);
            jfile.Save(Catalog);
            return RedirectToAction("Index",new { id = Catalog.Books.Count-1 });
        }

        public ActionResult Del(int id)
        {
            InitializationBooks();
            int bookCounts = Catalog.Books.Count - 1;
            ViewBag.BookCounts = bookCounts;
            
            return View();
        }
        [HttpPost]
        public ActionResult Del(Book book)
        {
            InitializationBooks();
            var d = Catalog.Books.FirstOrDefault(x => x.BookId == book.BookId);
            Catalog.Del(d.BookId);
            jfile.Save(Catalog);
            return RedirectToAction("Del");
        }
    }
}