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
        // GET: Add
        public ActionResult Index()
        {
            return View();
        }

        // GET: Add/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            bookService.Add(input);
            return RedirectToAction("Create");
        }
        
        // GET: Add/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Add/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Add/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Add/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
