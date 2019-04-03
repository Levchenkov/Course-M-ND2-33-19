using BooksWebApplication.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksWebApplication.Controllers
{
    public class GetController : Controller
    {
        public BookRepository BooksRepo { get; set; }
        // GET: Get
        public ActionResult Index()
        {
            BooksRepo = new BookRepository();
            ViewBag.Books = BooksRepo.Books;
            return View(BooksRepo.Books);
        }

        // GET: Get/Details/5
        public ActionResult Details(int id)
        {
            BooksRepo = new BookRepository();
            var book = BooksRepo.Books.FirstOrDefault(x => x.Id == id);
            if (book == null) return new HttpNotFoundResult();
            var genres = new List<SelectListItem>();
            var names = Enum.GetNames(typeof(Genre));
            for (int i = 0; i < names.Length; i++)
            {
                genres.Add(new SelectListItem { Value = i.ToString(), Text = names[i] });
            }
            var langs = new List<SelectListItem>();
            var nlangs = Enum.GetNames(typeof(Langs));
            for (int i = 0; i < nlangs.Length; i++)
            {
                langs.Add(new SelectListItem { Value = i.ToString(), Text = nlangs[i] });
            }
            book.AvailableLanguages = langs;
            book.AvailableGenres = genres;
            return View(book);
        }

        // GET: Get/Create
        public ActionResult Create()
        {
            BooksRepo = new BookRepository();
            Book book = new Book();
            //book = BooksRepo.Books.FirstOrDefault(x => x.Id == id);
            if (book == null) return new HttpNotFoundResult();
            var genres = new List<SelectListItem>();
            var names = Enum.GetNames(typeof(Genre));
            for (int i = 0; i < names.Length; i++)
            {
                genres.Add(new SelectListItem { Value = i.ToString(), Text = names[i] });
            }
            var langs = new List<SelectListItem>();
            var nlangs = Enum.GetNames(typeof(Langs));
            for (int i = 0; i < nlangs.Length; i++)
            {
                langs.Add(new SelectListItem { Value = i.ToString(), Text = nlangs[i] });
            }
            book.AvailableLanguages = langs;
            book.AvailableGenres = genres;
            return View(book);
        }

        // POST: Get/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                BooksRepo = new BookRepository();
                BooksRepo.Add(book);
                BooksRepo.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Get/Edit/5
        public ActionResult Edit(int id)
        {
            BooksRepo = new BookRepository();
            //var book = BooksRepo.Books.FirstOrDefault(x => x.Id == id);            
            return RedirectToAction("Edit", "Post",  new { controller = "Post", id });            
        }

        // POST: Get/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Get/Delete/5
        public ActionResult Delete(int id)
        {
            BooksRepo = new BookRepository();
            BooksRepo.Delete(id);
            BooksRepo.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Get/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
