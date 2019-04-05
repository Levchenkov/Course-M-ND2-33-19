using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Course.Library.Domain.Contracts;
using Course.Library.Domain.Contracts.ViewModels;
using Course.Library.Data.Contracts.Entities;
namespace Course.Library.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService bookService;

        public HomeController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public ActionResult Index()
        {
            var viewModel = bookService.GetAll();    
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var book = bookService.Get(id);
            var genres = bookService.GetGenres();
            var languages = bookService.GetLanguages();
            ViewBag.Genres=genres;
            ViewBag.Languages=languages;
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(BookViewModel viewModel)
        {
            viewModel.Languages = new List<Language>();
            for (int i = 0; i < viewModel.tempLanguages.Count; i++)
            {
                viewModel.Languages.Add(new Language());
                viewModel.Languages.ElementAt(i).Title = viewModel.tempLanguages.ElementAt(i);
            }
            bookService.Save(viewModel);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            var genres = bookService.GetGenres();
            var languages = bookService.GetLanguages();
            ViewBag.Genres = genres;
            ViewBag.Languages = languages;
            return View();
        }

        public ActionResult Delete(int id)
        {
            bookService.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Create(BookViewModel viewModel)
        {
            viewModel.Languages = new List<Language>();
            for (int i = 0; i < viewModel.tempLanguages.Count; i++)
            {
                viewModel.Languages.Add(new Language());
                viewModel.Languages.ElementAt(i).Title = viewModel.tempLanguages.ElementAt(i);
            }
            bookService.Save(viewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}