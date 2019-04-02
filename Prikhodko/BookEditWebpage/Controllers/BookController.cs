using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prikhodko.BookCatalogue.Service.Contracts.Models;
using Prikhodko.BookCatalogue.Service.Contracts.Interfaces;
using AutoMapper;

namespace Prikhodko.BookCatalogue.PL.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly ILanguageService languageService;
        
        public BookController(IBookService bookService, ILanguageService languageService)
        {
            this.bookService = bookService;
            this.languageService = languageService;
        }

        // GET: Add/Create
        public ActionResult Create()
        {
            var model = new BookViewModel();
            ViewBag.Languages = languageService.GetAllCodes(); 
            return View(model);
        }

        // POST: Add/Create
        [HttpPost]
        public ActionResult Create(BookViewModel input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            if(input.AvailableLanguages == null)
            {
                input.AvailableLanguages = new List<string>();
            }
            bookService.Add(input);
            return RedirectToAction("ShowCollection");
        }
        

        // GET: Add/Edit/5
        public ActionResult Edit(int id)
        {
            var model = bookService.Get(id);
            ViewBag.Languages = languageService.GetAllCodes();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BookViewModel input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            if (input.AvailableLanguages == null)
            {
                input.AvailableLanguages = new List<string>();
            }
            bookService.Update(input);
            return RedirectToAction("ShowCollection");
        }

        // GET: Add/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        
        public ActionResult ShowCollection()
        {
            var model = bookService.GetAll();
            return View(model);
        }
    }
}
