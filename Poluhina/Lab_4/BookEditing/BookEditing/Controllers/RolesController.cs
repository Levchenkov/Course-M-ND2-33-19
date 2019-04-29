using BookEditing.Models;
using BookEditing.Models.Roles;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookEditing.Controllers
{
    public class RolesController : Controller
    {
        private RoleManagerProvider RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<RoleManagerProvider>();
            }
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var ListRoles = RoleManager.Roles.ToList();
            return View(ListRoles);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(string id)
        {
            var userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<UserManagerProvider>();
            var user = userManager.FindByEmail(User.Identity.Name);
            if (user != null)
                userManager.RemoveFromRoles(user.Id, "user");
            return RedirectToAction("Index");
        }
    }
}