using lab4.DAL;
using lab4.Models;
using lab4.Models.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace lab4.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        public ActionResult Index() => View(db.Books.ToList());


        public ActionResult Create() => View();
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.ApplicationUser = User.Identity.GetUserName();
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index", "Book");
            }
            else
            {
                return View(book);
            }
        }

        public ActionResult Edit(int? id)
        {
            return View(db.Books.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Book book, int? id)
        {
            Book oldBook = db.Books.Find(id);
            
            oldBook.UpdatedBy = User.Identity.GetUserName();
            oldBook.UpdatedTime = DateTime.Now;

            oldBook.Description = book.Description;
            oldBook.Title = book.Title;

            db.Entry(oldBook).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Book");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}