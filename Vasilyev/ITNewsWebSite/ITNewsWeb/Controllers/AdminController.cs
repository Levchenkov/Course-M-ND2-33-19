using Http.News.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITNewsWeb.Controllers
{
    public class AdminController : Controller
    {
        private INewsService _newsService;

        public AdminController(INewsService newsService)
        {
            _newsService = newsService;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin, writer")]
        public ActionResult ViewAllNews()
        {
            var items = _newsService.GetAllItems().AsEnumerable();
            return View(items);
        }
    }
}