using System;
using System.Web.Mvc;
using Validation.Models;

namespace Validation.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult ValidateAmount(decimal? amount)
        {
            var isValid = amount.HasValue && amount.Value != 666m;
            return Json(isValid, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            var random = new Random();
            var order = new FluentOrder
            {
                Id = id,
                Title = $"Xiaomi Redmi {random.Next(2, 10)}",
                Amount = random.Next(100, 1000),
                Discount = random.Next(1, 10)
            };

            ViewBag.Message = Localization.Loaded;

            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(FluentOrder order)
        {
            if (order.Title.Contains("duck"))
            {
                ModelState.AddModelError(nameof(FluentOrder.Title), "Don't use duck in the internet.");
            }

            if (ModelState.IsValid)
            {
                ViewBag.Message = "Saved.";
            }
            else
            {
                ViewBag.Message = "Model is not valid";
            }
            return View(order);
        }
    }
}