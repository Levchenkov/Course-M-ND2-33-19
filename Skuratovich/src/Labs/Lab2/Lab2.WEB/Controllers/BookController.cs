using System.Linq;
using Lab2.Contracts;
using Lab2.Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab2.WEB.Controllers
{
    public class BookController : Controller
    {
        private IRepositoryWrapper repository;

        public BookController(IRepositoryWrapper repository)
        {
            this.repository = repository;
        }

        // GET: Book
        public IActionResult Index()
        {
            return View(repository.Book.GetAllBooks().ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Book book = repository.Book.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            var book = new Book();
            return View(book);
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Title,Description,Author,Created,Genre,IsPaper,Languages,DeliveryRequired")] Book book)
        {
            if (ModelState.IsValid)
            {
                repository.Book.CreateBook(book);

                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Book book = repository.Book.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, [Bind("Id,Title,Description,Author,Created,Genre,IsPaper,Languages,DeliveryRequired")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                repository.Book.UpdateBook(book);
                //TODO: read about logger
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
            return View(book);
        }

        // GET: Book/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Book book = repository.Book.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = repository.Book.GetBookById(id);
            repository.Book.DeleteBook(book);

            return RedirectToAction("Index");
        }
    }
}
