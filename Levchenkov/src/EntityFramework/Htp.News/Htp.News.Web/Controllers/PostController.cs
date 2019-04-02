using System.Web.Mvc;
using Htp.News.Domain.Contracts;
using Htp.News.Domain.Contracts.ViewModels;

namespace Htp.News.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        public ActionResult Display(int id)
        {
            var post = postService.Get(id);
            return View(post);
        }

        public ActionResult Edit(int id)
        {
            var post = postService.Get(id);
            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(PostViewModel viewModel)
        {
            postService.Save(viewModel);
            return RedirectToAction("Edit", new {id = viewModel.Id});
        }
    }
}