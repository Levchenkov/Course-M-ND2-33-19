using Course.FrontendPart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Course.Client.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IBookService bookService;
        public HomeController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display()
        {
            var result = bookService.GetAll();
            return View(result);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(BookViewModel viewModel)
        {
            viewModel.UpdatedBy = User.Identity.GetUserName();
            bookService.Put(viewModel, viewModel.Id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var viewModel = bookService.Get(id);
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(BookViewModel viewModel)
        {
            viewModel.CreatedBy = User.Identity.GetUserName();
            viewModel.UpdatedBy = User.Identity.GetUserName();
            bookService.Post(viewModel);
            return RedirectToAction("Display");
        }

        public ActionResult Delete(int id)
        {
            bookService.Delete(id);
            return RedirectToAction("Display");
        }

    }
}