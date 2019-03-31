using System.Web.Mvc;
using Htp.News.Domain.Contracts;

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
    }
}