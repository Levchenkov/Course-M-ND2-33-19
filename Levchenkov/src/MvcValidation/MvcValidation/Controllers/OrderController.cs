using MvcValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcValidation.Controllers
{
    public class OrderController : Controller
    {
        public JsonResult ValidateTitle(string title)
        {
            var isValid = title != "Spider Man 4 - DVD";
            return Json(isValid, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            var random = new Random();
            var order = new Order
            {
                Id = id,
                Title = $"Spider Man {random.Next(1, 4)} - DVD",
                Amount = random.Next(20, 100),
                Discount = random.Next(1, 10)
            };
            ViewBag.Message = "Get";
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (order.Title.Contains("MAN"))
            {
                ModelState.AddModelError(nameof(order.Title), "Don't use CAPS!!11!");
            }

            if(order.Amount - order.Discount < 10)
            {
                ModelState.AddModelError("", "You can't pay less than $10.");
            }

            if (ModelState.IsValid)
            {
                ViewBag.Message = "Post: Saved";
            }
            else
            {
                ViewBag.Message = "Post: Model is not valid";
            }
            return View(order);
        }
    }
}
