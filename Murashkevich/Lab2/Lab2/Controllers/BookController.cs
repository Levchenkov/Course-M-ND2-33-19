using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookList;

namespace Lab2.Controllers
{
    public class BookController : Controller
    {
        static IFileHandler<Book> fileHandler = new FileHandler();
        static IBookRepository<Book> bookRepository = new BookRepository(fileHandler);

        public ActionResult Show()
        {
            IEnumerable<Book> books = fileHandler.Load();
            ViewBag.Books = books;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            bookRepository.Add(book);
            bookRepository.SaveChanges();
            return RedirectToAction("Show");
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, Book book)
        {
            bookRepository.Edit(id,book);
            bookRepository.SaveChanges();
            return RedirectToAction("Show");
        }
    }
}