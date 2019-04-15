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
        
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                //book.ApplicationUser = new ApplicationUser();
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
    }
}