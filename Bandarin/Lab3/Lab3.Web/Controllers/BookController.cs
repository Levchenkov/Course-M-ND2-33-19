using Lab3.BLL.Contracts;
using Lab3.BLL.Contracts.ViewModels;
using Lab3.DAL.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;               

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public ActionResult Index(int id)
        {
            var book = bookService.Get(id);
            return View(book);
            
        }

        public ActionResult Add(int id)
        {
            if(bookService.Get(id)!= null)
            {
                return RedirectToAction("Edit", new { id = id });
            }

            var book = new BookViewModel() 
            {
                Title = "MyBook Title",
                Id = id,
                Author = "Author Name",

                Description = "Say Hello",
                Created = DateTime.Now,
                GenreID = 1,
                GenresAvailable = new List<SelectListItem>
                {
                    new SelectListItem {Text= Genres.Adventure.ToString(), Value = ((int)Genres.Adventure).ToString()},
                    new SelectListItem {Text = Genres.Detective.ToString(), Value = ((int)Genres.Detective).ToString()},
                    new SelectListItem {Text = Genres.SciFi.ToString(), Value = ((int)Genres.Horror).ToString()},
                    new SelectListItem {Text = Genres.Romance.ToString(), Value = ((int)Genres.Romance).ToString()}
                },

                IsPaper = false,
                LanguagesID = new[] {1,2},

                LanguageAvailable = new List<SelectListItem>
                {
                    new SelectListItem() {Text = "Russian",Value = 1.ToString() },
                    new SelectListItem() {Text = "German",Value = 2.ToString() },
                    new SelectListItem() {Text = "English",Value = 3.ToString() },
                    new SelectListItem() {Text = "Spanish",Value = 4.ToString() },
                    new SelectListItem() {Text = "French",Value = 5.ToString() }
                },

                DeliveryType = TypesofDelivery.Required
            };
            return View(book);
        }
        

        [HttpPost]
        public ActionResult Add(BookViewModel viewModel) 
        {
            bookService.Add(viewModel);
            return RedirectToAction("Index", new { id = viewModel.Id });
                                  
        }

        public ActionResult Edit(int id)

        {
            var book = bookService.Get(id);
            book.GenresAvailable = new List<SelectListItem>
                {
                    new SelectListItem {Text= Genres.Adventure.ToString(), Value = ((int)Genres.Adventure).ToString()},
                    new SelectListItem {Text = Genres.Detective.ToString(), Value = ((int)Genres.Detective).ToString()},
                    new SelectListItem {Text = Genres.SciFi.ToString(), Value = ((int)Genres.Horror).ToString()},
                    new SelectListItem {Text = Genres.Romance.ToString(), Value = ((int)Genres.Romance).ToString()}
                };
            book.LanguageAvailable = new List<SelectListItem>
                {
                    new SelectListItem() {Text = "Russian",Value = 1.ToString() },
                    new SelectListItem() {Text = "German",Value = 2.ToString() },
                    new SelectListItem() {Text = "English",Value = 3.ToString() },
                    new SelectListItem() {Text = "Spanish",Value = 4.ToString() },
                    new SelectListItem() {Text = "French",Value = 5.ToString() }
                };
            book.DeliveryType = TypesofDelivery.Required;


            return View(book);

        }

        [HttpPost]
        public ActionResult Edit(BookViewModel viewModel)
        {
            bookService.Save(viewModel);
            return RedirectToAction("Index", new { id = viewModel.Id });
            
        }

        public ActionResult Remove(int id)
        {
            var book = bookService.Get(id);
            return View(book);
        }

        [HttpPost]
        public ActionResult Remove(BookViewModel viewModel)
        {

            bookService.Remove(viewModel);
            return RedirectToAction("Index", new { id = viewModel.Id });
        }
    }
}