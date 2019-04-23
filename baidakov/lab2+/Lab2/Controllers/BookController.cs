using Lab2.Models;
using System.Web.Mvc;


namespace Lab2.Controllers
{
    public class BookController : Controller
    {
        private readonly IRepository<Book> booklist = new BookRepository(new JsonFileHandler());

        public ActionResult ViewBook()
        {
            return View(booklist.View());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            booklist.Add(book);
            booklist.SaveChanges();
            return RedirectToAction("ViewBook");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
         return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, Book book)
        {
            booklist.Edit(id, book);
            booklist.SaveChanges();
            return RedirectToAction("ViewBook");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            booklist.Delete(id);
            booklist.SaveChanges();
            return RedirectToAction("ViewBook");
        }

    }
}
