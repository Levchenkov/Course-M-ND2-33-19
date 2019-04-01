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
        // GET: /HelloWorld/Welcome/

        public string Test()
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

        // GET: Book/HistoryLog/5
        public IActionResult HistoryLog(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            return View(bookService.GetHistoryLogs(id.GetValueOrDefault()).ToList());
        }

        // GET: Book/Create
        public ActionResult Create()
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
        public ActionResult Create(int? id, [Bind("Id,Title,Description,Author,Created,GenreId,IsPaper,RowVersion,DeliveryRequired,Genres")] BookViewModel bookViewModel)
        //public ActionResult Create([Bind("Id,Title,Description,Author,Created,Genre,IsPaper,Languages,DeliveryRequired")] Book book)
        {
            if (ModelState.IsValid)
            {
                bookService.Add(bookViewModel);

                return RedirectToAction("Index");
            }

            return View(bookViewModel);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
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
        //public ActionResult Edit(int? id, [Bind("Id,Title,Description,Author,Created,Genre,IsPaper,Languages,DeliveryRequired")] Book book)
        public ActionResult Edit(int? id, [Bind("Id,Title,Description,Author,Created,GenreId,IsPaper,RowVersion,DeliveryRequired,Genres")] BookViewModel bookViewModel)
        {
            if (id.GetValueOrDefault() != bookViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bookService.Edit(bookViewModel);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
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
    }
}
