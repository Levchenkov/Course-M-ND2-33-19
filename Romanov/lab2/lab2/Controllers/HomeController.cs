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
        public ActionResult Book()
        {
            JsonFile jfile = new JsonFile();
            Catalog catalog = jfile.Load();
            List<Book> books = catalog.Books;
            ViewBag.Books = books;
            return View();
        }
    }
}