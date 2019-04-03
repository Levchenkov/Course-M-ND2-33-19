using BookEditing.Models;
using System.Linq;
using System.Web.Mvc;
using BookEditing.Additional_methods;

namespace BookEditing.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Book> db;
        public HomeController()
        {
            db = new BookRepository(new JsonFormat());
        }
        public ActionResult Index()
        {
            return View(db.GetBooks());
        }

        [HttpPost]
        public ActionResult Add(Book book)
        {
            var listId = db.GetBooks().Select(x => x.Id);
            if (listId.Contains(book.Id))
            {
                ViewBag.ServerReply = "My Message.";
                return View(book);
            }
            db.Add(book);
            db.SerializeAndSave();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id.Equals(0))
            {
                return HttpNotFound();
            }
            db.Remove(id);
            db.SerializeAndSave();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var book = db.GetBooks()?.First(x => x.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            db.Change(book.Id, book);
            db.SerializeAndSave();
            return RedirectToAction("Index");
        }
    }
}

