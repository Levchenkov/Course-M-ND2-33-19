using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookCataloguePL.Models;
using AutoMapper;
using BookCatalogue;

namespace BookCataloguePL.Controllers
{
    public class BookController : Controller
    {
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
            return View(model);
        }

        // POST: Add/Create
        [HttpPost]
        public ActionResult Create(BookViewModel input)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BookViewModel, Book>());
            var book = Mapper.Map<BookViewModel, Book>(input);
            IService<Book> service = new BookService(new JsonBookRepository());
            service.Add(book);
            return RedirectToAction("../Home/Index");
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
