using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab2.Models;

using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class BookController : Controller
    {

        public ActionResult EditBook(int id)
        {
            Books book = new Books()
            {
                Title = "MyBook Title",
                Id = id,
                Author = "Author Name",

                Description = "Say Hello",
                Created = DateTime.Now,
                Genre = GenreType.Fantasy,
                GenresAvailable = new List<SelectListItem>
                {
                    new SelectListItem {Text= GenreType.Adventure.ToString(), Value = ((int)GenreType.Adventure).ToString()},
                    new SelectListItem {Text = GenreType.Detective.ToString(), Value = ((int)GenreType.Detective).ToString()},
                    new SelectListItem {Text = GenreType.SciFi.ToString(), Value = ((int)GenreType.SciFi).ToString()},
                    new SelectListItem {Text = GenreType.Romance.ToString(), Value = ((int)GenreType.Romance).ToString()}
                },

                IsPaper = false,
                Languages = new[] {1,2},

                LanguageAvailable = new List<SelectListItem>
                {
                    new SelectListItem() {Text = "English",Value = 1.ToString() },
                    new SelectListItem() {Text = "Spanish",Value = 2.ToString() },
                    new SelectListItem() {Text = "German",Value = 3.ToString() },
                    new SelectListItem() {Text = "French",Value = 4.ToString() },
                    new SelectListItem() {Text = "Russian",Value = 5.ToString() }
                },

                DeliveryRequired = DeliveryType.Required
            };

            ViewData["BookTitle"] = book.Title;

            return View(book);
        }
        
            
            [HttpPost]
            public ActionResult EditBook(Books book)
            {
            var filework = new JsonFileWorker();
            var repository = new BookRepository(filework);
            try
            {
                repository.Get(book.Id);
            }
            catch
            {
                repository.Add(book);
            }
            finally
            {
                repository.Edit(book);
            }
            
            repository.Save();
           

                return RedirectToAction("EditBook",new { id = book.Id });
            }
        
    

    }
}