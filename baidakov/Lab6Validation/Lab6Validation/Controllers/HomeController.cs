using Lab6Validation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.Results;
using System.Web.Mvc;
using Lab6Validation.Validation;
using System.Threading;

namespace Lab6Validation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var pay = new Payment()
            {
                FirstName = "Anatoly",
                MiddleName = "Mihailovich",
                LastName = "Baidakov",
                Address = "Kalvariyskaya str., 43-1",
                City = "Minsk",
                Country = "Belarus",
                PostCode = "21001",
                Email = "am.baidakov@gmail.com",
                Amount = 123.45,
                Description = "test payment",
                CreditCardNumber = "4111111111111111",
                ExpirationMonth = 12,
                ExpirationYear = 2021,
                SecurityCode = "123"
            };

            return View(pay);
        }

        [HttpPost]
        public ActionResult Index(Payment pay)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Done");
            }
            else
            {
                return View(pay);
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            base.OnActionExecuting(filterContext);
        }
        public string Done()
        {
            return "Operation Completed Successfully";
        }
    }
}