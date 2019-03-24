using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            //ViewBag.Books = bookRepository.GetBooks();
            var books = new List<Book>();
            foreach (var book in bookRepository.GetBooks()) books.Add(book);

            return View(books.Select(x => new BookViewModel(x)));
        }

        public ActionResult Edit(int id)
        {
            // if (id == null)
            // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var book =
                bookRepository.GetBooks().FirstOrDefault(x => x.Id == id);

            if (book == null) throw new Exception("Book not found.");

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include =
                                     "Id,Title,Description,Author,Created,Genre,IsPaper,Languages,DeliveryRequired")]
                                 Book book)
        {
            if (!ModelState.IsValid) return View(book);

            if (true) return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var book =
                bookRepository.GetBooks().FirstOrDefault(x => x.Id == id);

            if (book == null) throw new Exception("Book not found.");


            bookRepository.Delete(id);
            return this.RedirectToAction("Index");
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