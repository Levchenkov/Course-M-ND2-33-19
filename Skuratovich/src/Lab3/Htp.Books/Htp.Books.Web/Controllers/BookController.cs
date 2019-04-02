using System;
using System.Linq;
using Htp.Books.Domain.Contracts;
using Htp.Books.Domain.Contracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Htp.Books.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        // 
        // GET: /Book/TestAction/

        public string TestAction()
        {
            return "This is the Test action method...";
         
        }

        // GET: Book
        public IActionResult Index()
        {
            return View(bookService.GetAll().ToList());
        }

        // GET: Book/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            BookViewModel bookViewModel = bookService.Get(id.GetValueOrDefault());
            if (bookViewModel == null)
            {
                return NotFound();
            }
            return View(bookViewModel);
        }

        //// GET: Book/Create
        public IActionResult Create()
        {
            var bookViewModel = new BookViewModel
            {
                Genres = bookService.GetGenres()
            };
            return View(bookViewModel);
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int? id, [Bind("Id,Title,Description,Author,Created,GenreId,IsPaper,RowVersion,DeliveryRequired,Genres")] BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                bookService.Add(bookViewModel);

                return RedirectToAction("Index");
            }

            return View(bookViewModel);
        }

        // GET: Book/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            BookViewModel bookViewModel = bookService.Get(id.GetValueOrDefault());
            if (bookViewModel == null)
            {
                return NotFound();
            }
            bookViewModel.Genres = bookService.GetGenres();
            return View(bookViewModel);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind("Id,Title,Description,Author,Created,GenreId,IsPaper,RowVersion,DeliveryRequired,Genres")] BookViewModel bookViewModel)
        {
            if (id.GetValueOrDefault() != bookViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bookService.Edit(bookViewModel);
                //repository.Book.UpdateBook(book);
                ////TODO: read about logger
                //try
                //{
                //    _repository.Book.UpdateBook(book);
                //    //await _context.SaveChangesAsync();
                //}
                //catch (Exception ex)
                //{
                //    //if (!MovieExists(movie.ID))
                //    //{
                //    //    return NotFound();
                //    //}
                //    //else
                //    //{
                //    //    throw;
                //    //}
                //}
                return RedirectToAction("Index");
            }
            return View(bookViewModel);
        }

        // GET: Book/HistoryLog/5
        public IActionResult HistoryLog(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            return View(bookService.GetHistoryLogs(id.GetValueOrDefault()).ToList());
        }

        // GET: Book/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            BookViewModel bookViewModel = bookService.Get(id.GetValueOrDefault());
            if (bookViewModel == null)
            {
                return NotFound();
            }
            bookViewModel.Genres = bookService.GetGenres();
            return View(bookViewModel);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int? id)
        public IActionResult DeleteConfirmed(int? id, [Bind("Id,Title,Description,Author,Created,GenreId,IsPaper,RowVersion,DeliveryRequired,Genres")] BookViewModel bookViewModel)
        {
            if (id.GetValueOrDefault() != bookViewModel.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                bookService.Delete(bookViewModel);
            }
            return RedirectToAction("Index");
        }

        //// GET: Book/Test/5
        //public ActionResult Test(int? id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest();
        //    }
        //    BookViewModel bookViewModel = bookService.Get(id.GetValueOrDefault());
        //    if (bookViewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    bookViewModel.Genres = bookService.GetGenres();
        //    return View(bookViewModel);
        //}

        //// POST: Book/Test/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////public ActionResult Edit(int? id, [Bind("Id,Title,Description,Author,Created,Genre,IsPaper,Languages,DeliveryRequired")] Book book)
        //public ActionResult Test(int? id, [Bind("Id,Title,Description,Author,Created,GenreId,IsPaper,RowVersion,DeliveryRequired,Genres")] BookViewModel bookViewModel)
        //{
        //    if (id.GetValueOrDefault() != bookViewModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            bookService.Test(bookViewModel);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    return View(bookViewModel);
        //}
    }
}
