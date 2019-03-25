using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication16.Models;

namespace WebApplication16.Controllers
{
    public class PostController : Controller
    {
        public ActionResult Edit(int id)
        {
            var post = new Post
            {
                Created = DateTime.Now,
                Id = id,
                Title = "My Super Urgent News",
                Description = "My Super Urgent News",
                Version = PostVersion.Published,
                Category = Category.Auto,
                AvailableCategories = new List<SelectListItem>
                {
                    new SelectListItem { Value = ((int)Category.Auto).ToString(), Text = Category.Auto.ToString()},
                    new SelectListItem { Value = ((int)Category.Finance).ToString(), Text = Category.Finance.ToString()},
                    new SelectListItem { Value = ((int)Category.People).ToString(), Text = Category.People.ToString()},
                },
                Tags = new [] { 1, 2},
                AvailableTags = new List<SelectListItem>
                {
                    new SelectListItem() { Value = 1.ToString(), Text = "Urgent"},
                    new SelectListItem() { Value = 2.ToString(), Text = "Auto"},
                    new SelectListItem() { Value = 3.ToString(), Text = "Hero"},
                    new SelectListItem() { Value = 4.ToString(), Text = "Movies", Disabled = true },
                },
                IsCommentable = true,
                Comments = new List<Comment>
                {
                    new Comment { Content = "First Comment"},
                    new Comment { Content = "One More Comment"},
                    new Comment { Content = "And One More Comment"}
                }
            };

            ViewData["PageTitle"] = post.Title;
            ViewBag.PageTitleLower = post.Title.ToLower();

            TempData["Author"] = "Ivan Ivanov";

            Session["Created"] = DateTime.Now;

            dynamic d = new ExpandoObject();
            d.Title = "qwe";

            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            var title = ViewData["PageTitle"];
            var author = TempData["Author"];
            var created = Session["Created"];
            return RedirectToAction("Edit", new {id = post.Id});
        }
    }
}