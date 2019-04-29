using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksWebApplication.Models;
using Models;

namespace BooksWebApplication.Controllers
{
    public class PostController : Controller
    {
        public readonly BookRepository BooksRepo = new BookRepository();
        // GET: Get
        public ActionResult Index()
        {
            return View(BooksRepo.GetList());
        }

        // GET: Get/Details/5
        public ActionResult Details(int id)
        {
            var book = BooksRepo.GetList().FirstOrDefault(x => x.Id == id);
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
            Book book = new Book();
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
                BooksRepo.Add(book);
                BooksRepo.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        //[HttpPost]
        public ActionResult Edit(int id)
        {            
            Book book = new Book();
            book = BooksRepo.GetList().FirstOrDefault(x => x.Id == id);
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
            ViewData["PageTitle"] = book.Title;
            ViewBag.PageTitleLower = book.Title.ToLower();
            //TempData["Author"] = "Jeffrey Richter";
            Session["Created"] = DateTime.Now;
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            BooksRepo.Change(book);
            BooksRepo.SaveChanges();
            var title = ViewData["BookTitle"];
            var author = TempData["Author"];
            var created = Session["Created"];
            return RedirectToAction("Edit", new { id = book.Id });
        }

        // GET: Get/Delete/5
        public ActionResult Delete(int id)
        {
            BooksRepo.Delete(id);
            BooksRepo.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
