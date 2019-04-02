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

        // GET: Post/Edit/5
        //[HttpPost]
        public ActionResult Edit(int id)
        {
            BooksRepo = new BookRepository();
            Book book = new Book();
            book = BooksRepo.Books.FirstOrDefault(x => x.Id == id);
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
            //var book = new Book
            //{
            //    Created = DateTime.Now,
            //    Id = id,
            //    Title = "CLR VIA C#",
            //    Description = "Book for C# programmers",
            //    Author = "Jeffrey Richter",
            //    Genre = Genre.ReferenceBooks,
            //    IsPaper = true,
            //    DeliveryRequired = false,
            //    Languages = new [] { (int)Langs.English, (int)Langs.Russian },
            //    AvailableGenres = genres,
            //    AvailableLanguages = langs,
            //    //AvailableGenres = new List<SelectListItem>
            //    //{
            //    //    new SelectListItem { Value = ((int)Genre.ActionAndAdventure).ToString(), Text = Genre.ActionAndAdventure.ToString()},
            //    //    new SelectListItem { Value = ((int)Genre.Anthology).ToString(), Text = Genre.Anthology.ToString()},
            //    //    new SelectListItem { Value = ((int)Genre.Biography_Autobiography).ToString(), Text = Genre.Biography_Autobiography.ToString()},
            //    //},
            //    //Tags = new[] { 1, 2 },
            //    //AvailableTags = new List<SelectListItem>
            //    //{
            //    //    new SelectListItem() { Value = 1.ToString(), Text = "Urgent"},
            //    //    new SelectListItem() { Value = 2.ToString(), Text = "Auto"},
            //    //    new SelectListItem() { Value = 3.ToString(), Text = "Hero"},
            //    //    new SelectListItem() { Value = 4.ToString(), Text = "Movies", Disabled = true },
            //    //},
            //    //IsCommentable = true,
            //    //Comments = new List<Comment>
            //    //{
            //    //    new Comment { Content = "First Comment"},
            //    //    new Comment { Content = "One More Comment"},
            //    //    new Comment { Content = "And One More Comment"}
            //    //}
            //};

            ViewData["PageTitle"] = book.Title;
            ViewBag.PageTitleLower = book.Title.ToLower();

            //TempData["Author"] = "Jeffrey Richter";

            Session["Created"] = DateTime.Now;

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            BooksRepo = new BookRepository();
            BooksRepo.Change(book);
            BooksRepo.SaveChanges();
            var title = ViewData["BookTitle"];
            var author = TempData["Author"];
            var created = Session["Created"];
            return RedirectToAction("Edit", new { id = book.Id });
        }

        // POST: Post/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

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
