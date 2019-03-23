using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab2.WEB.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //// 
        //// GET: /HelloWorld/

        //public string Index()
        //{
        //    return "This is my default action...";
        //}

        ////// GET: /<controller>/
        ////public IActionResult Index()
        ////{
        ////    return View();
        ////}
    }
}
