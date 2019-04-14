using BookEditing.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace BookEditing.Controllers
{
    public class AccountController : Controller
    {
        private UserManagerProvider UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<UserManagerProvider>();
            }
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(UserRegister model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, "user");
                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    return RedirectToAction("LoginEnter", "Account");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(model);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        public ActionResult LoginEnter(string url)
        {
            ViewBag.url = url;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginEnter(Login model, string url)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "wrong login or password.");
                }
                else
                {
                    var claim = await UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    if (String.IsNullOrEmpty(url))
                        return RedirectToAction("Index", "Home");
                    return Redirect(url);
                }
            }
            ViewBag.returnUrl = url;
            return View(model);
        }
        //удаляет аутентификационные куки
        public ActionResult LogSignOut()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("LoginEnter");
        }

        [HttpGet]
        public async Task<ActionResult> Delete()
        {
            var user = await UserManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                var result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("LogSignOut", "Account");
                }
            }
            return RedirectToAction("Register", "Account");
        }
    }
}