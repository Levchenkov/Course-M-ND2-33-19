using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLibrary.Models;

namespace WebLibrary.Controllers
{
    public class HomeController : Controller
    {
        BookService library = new BookService(new JsonFileHandler());
        public ActionResult Show()
        {
            JsonFileHandler ShowLibrary = new JsonFileHandler();
            return View(ShowLibrary.Load());
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult Add(Book tempBook)
        {
            library.Add(tempBook);
            return RedirectToAction("Show");
        }
        [HttpPost]
        public ActionResult Edit(Book tempBook)
        {
            library.Change(tempBook);
            return RedirectToAction("Show");
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Remove(int Id)
        {
            library.Remove(Id);
            return RedirectToAction("Show");
        }
   }
}