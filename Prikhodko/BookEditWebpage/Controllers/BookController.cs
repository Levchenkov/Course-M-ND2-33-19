using System.Web.Mvc;
using BookCataloguePL.Models;
using AutoMapper;
using BookCatalogue;

namespace BookCataloguePL.Controllers
{
    public class BookController : Controller
    {

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
    }
}
