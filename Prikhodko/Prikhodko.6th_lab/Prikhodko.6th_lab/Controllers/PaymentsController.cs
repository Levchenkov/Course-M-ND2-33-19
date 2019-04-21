using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prikhodko._6th_lab.Models;

namespace Prikhodko._6th_lab.Controllers
{
    public class PaymentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult New(PaymentViewModel model)
        {
            return View(model);
        }
    }
}