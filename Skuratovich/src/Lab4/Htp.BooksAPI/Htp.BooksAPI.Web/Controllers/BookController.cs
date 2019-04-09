using System;
using System.Threading.Tasks;
using Htp.BooksAPI.Data.Contracts.Entities;
using Htp.BooksAPI.Domain.Contracts;
using Htp.BooksAPI.Domain.Contracts.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Htp.BooksAPI.Server.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly UserManager<AppUser> userManager;

        public BookController(IBookService bookService, UserManager<AppUser> userManager)
        {
            this.bookService = bookService;
            this.userManager = userManager;
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
            return View(bookService.GetAll());
            //return null;
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            BookViewModel bookViewModel = await bookService.GetAsync(id.GetValueOrDefault());
            if (bookViewModel == null)
            {
                return NotFound();
            }

            return View(bookViewModel);
        }

        //// GET: Book/Details/5
        //public IActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest();
        //    }
        //    BookViewModel bookViewModel = bookService.GetAsync(id.GetValueOrDefault());
        //    if (bookViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(bookViewModel);
        //}

        //// GET: Book/Create
        public IActionResult Create()
        {
            var bookViewModel = new BookViewModel();

            return View(bookViewModel);
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int? id, [Bind("Id,Title,Description")] BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                bookViewModel.CreatedByUserID = userManager.GetUserId(User);
                bookService.Add(bookViewModel);

                return RedirectToAction("Index");
            }

            return View(bookViewModel);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            BookViewModel bookViewModel = await bookService.GetAsync(id.GetValueOrDefault());
            if (bookViewModel == null)
            {
                return NotFound();
            }
            return View(bookViewModel);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind("Id,Title,Description")] BookViewModel bookViewModel)
        {
            if (id.GetValueOrDefault() != bookViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bookViewModel.UpdatedByUserID = userManager.GetUserId(User);
                bookService.EditAsync(bookViewModel);
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

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            BookViewModel bookViewModel = await bookService.GetAsync(id.GetValueOrDefault());
            if (bookViewModel == null)
            {
                return NotFound();
            }
            return View(bookViewModel);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id, [Bind("Id, Title")] BookViewModel bookViewModel)
        {
            if (id.GetValueOrDefault() != bookViewModel.Id)
            {
                return NotFound();
            }
            bookService.DeleteAsync(bookViewModel.Id);
            return RedirectToAction("Index");
        }
    }
}
