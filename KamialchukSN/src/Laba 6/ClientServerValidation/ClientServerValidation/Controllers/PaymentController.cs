using ClientServerValidation.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ClientServerValidation.Controllers
{
    public class PaymentController : Controller
    {
        public PaymentController()
        {
            Payments = new List<Payment>();
        }
        public List<Payment> Payments { get; set; }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Payment payment)
        {
            if (!ModelState.IsValid)
            { 
                return View("Create", payment);
            }
            Payments.Add(payment);

            return RedirectToAction("Create");
        }
    }
}