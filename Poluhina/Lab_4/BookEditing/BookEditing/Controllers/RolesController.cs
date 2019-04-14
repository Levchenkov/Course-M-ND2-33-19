using BookEditing.Models;
using BookEditing.Models.Roles;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
        public  ActionResult Index()
        {
           var ListRoles = RoleManager.Roles.ToList();
            return View(ListRoles);
        }
       
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<ActionResult> Create(CreateRoleModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await RoleManager.CreateAsync(new Role
        //        {
        //            Name = model.Name,
        //            Description = model.Description
        //        });
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Something went wrong");
        //        }
        //    }
        //    return View(model);
        //}
        //[HttpGet]
        //public async Task<ActionResult> EditRole(string id)
        //{
        //    var role = await RoleManager.FindByIdAsync(id);
        //    if (role != null)
        //    {
        //        return View(new EditRoleModel { Id = role.Id, Name = role.Name, Description = role.Description });
        //    }
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public async Task<ActionResult> EditRole(EditRoleModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var role = await RoleManager.FindByIdAsync(model.Id);
        //        if (role != null)
        //        {
        //            role.Description = model.Description;
        //            role.Name = model.Name;
        //            var result = await RoleManager.UpdateAsync(role);
        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "Something went wrong");
        //            }
        //        }
        //    }
        //    return View(model);
        //}
        //[HttpGet]
        //public async Task<ActionResult> Delete(string id)
        //{
        //    var role = await RoleManager.FindByIdAsync(id);
        //    if (role != null)
        //    {
        //        var result = await RoleManager.DeleteAsync(role);
        //    }
        //    return RedirectToAction("Index");
        //}
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(string id)
        {
            var userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<UserManagerProvider>();
            var user = userManager.FindByEmail(User.Identity.Name);
            if (user != null)
               userManager.RemoveFromRoles(user.Id,"user");
            return RedirectToAction("Index");
        }
    }
}