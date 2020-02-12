using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ITNewsWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace ITNewsWeb.Controllers
{
    public class ManageUsersController : Controller
    {
        private readonly ApplicationDbContext context;
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ManageUsersController()
        {
            context = new ApplicationDbContext();
        }

        [Authorize(Roles = "admin")]
        public ActionResult UsersWithRoles()
        {
            var usersWithRoles = (from user in context.Users
                select new
                {
                    UserId = user.Id,
                    Username = user.UserName,
                    user.Email,
                    RoleNames = (from userRole in user.Roles
                        join role in context.Roles on userRole.RoleId
                            equals role.Id
                        select role.Name).ToList(),
                    user.LockoutEnabled,
                    user.LockoutEndDateUtc,
                }).ToList().Select(p => new UsersInRoleViewModel
            {
                UserId = p.UserId,
                Username = p.Username,
                Email = p.Email,
                Role = string.Join(",", p.RoleNames),
                LockoutEnabled =  p.LockoutEnabled,
                LockoutEndDateUtc = p.LockoutEndDateUtc,
                });


            return View(usersWithRoles);
        }

        [Authorize(Roles = "admin")]
        public ActionResult ResetUserPassword(string userId, string UserName)
        {
            ViewBag.Username = UserName.ToString();
            ViewBag.UserId = userId.Trim().ToString();
            return View();
        }

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> LockOut(string userId)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(userId);

            if (user != null)
            {
                user.LockoutEnabled = true;
                user.LockoutEndDateUtc = DateTime.Now;
                await UserManager.UpdateAsync(user);
            }
            TempData["Message"] = "User Locked Successfully. ";
            TempData["MessageValue"] = "1";
            return RedirectToAction("UsersWithRoles");
        }

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> UnlockOut(string userId)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(userId);

            if (user != null)
            {
                user.LockoutEnabled = false;
                user.LockoutEndDateUtc = null;
                await UserManager.UpdateAsync(user);
            }
            TempData["Message"] = "User Unlocked Successfully. ";
            TempData["MessageValue"] = "1";
            return RedirectToAction("UsersWithRoles");
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult ResetUserPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
                if (userManager.HasPassword(model.UserId))
                {
                    userManager.RemovePassword(model.UserId);
                    userManager.AddPassword(model.UserId, model.ConfirmPassword);

                }

                TempData["Message"] = "Password successfully reset to " + model.ConfirmPassword;
                TempData["MessageValue"] = "1";

                return RedirectToAction("UsersWithRoles", "ManageUsers", new { area = "", });
            }

            // If we got this far, something failed, redisplay form
            TempData["Message"] = "Invalid User Details. Please try again in some minutes ";
            TempData["MessageValue"] = "0";
            return RedirectToAction("UsersWithRoles", "ManageUsers", new { area = "", });
        }

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> DeleteUserd(string userId)
        {
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //get User Data from Userid
            var user = await UserManager.FindByIdAsync(userId);

            //List Logins associated with user
            var logins = user.Logins;

            //Gets list of Roles associated with current user
            var rolesForUser = await UserManager.GetRolesAsync(userId);

            using (var transaction = context.Database.BeginTransaction())
            {
                foreach (var login in logins.ToList())
                {
                    await UserManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                }

                if (rolesForUser.Count() > 0)
                {
                    foreach (var item in rolesForUser.ToList())
                    {
                        // item should be the name of the role
                        var result = await UserManager.RemoveFromRoleAsync(user.Id, item);
                    }
                }

                //Delete User
                await UserManager.DeleteAsync(user);

                TempData["Message"] = "User Deleted Successfully. ";
                TempData["MessageValue"] = "1";
                //transaction.commit();
            }

            return RedirectToAction("UsersWithRoles", "ManageUsers", new { area = "", });
        }
    }
}