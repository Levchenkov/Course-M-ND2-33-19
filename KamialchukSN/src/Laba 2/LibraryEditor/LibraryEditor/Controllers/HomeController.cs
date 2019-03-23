using LibraryEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryEditor.Controllers
{
    public class HomeController : Controller
    {
        BookRepository bookRepository = new BookRepository(new JsonFileHandler());

        public ActionResult Index()
        {
            ViewBag.Books =  bookRepository.Data;
            return View();
        }
    }
}