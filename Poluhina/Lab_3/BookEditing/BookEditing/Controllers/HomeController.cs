using AutoMapper;
using BookEditing.BLL.DTO;
using BookEditing.BLL.Interfaces;
using BookEditing.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace BookEditing.Controllers
{
    public class HomeController : Controller
    {
        IBookService<BookDTO> bookService;
        public HomeController(IBookService<BookDTO> repository)
        {
            bookService = repository;
        }

        public ActionResult Index()
        {
            var booksDTO = bookService.GetList();
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookViewModel>()).CreateMapper();
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookDTO, BookViewModel>();
                cfg.CreateMap<LanguageDTO, SelectListItem>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name));
            }).CreateMapper();

            var books = mapper.Map<IEnumerable<BookDTO>, List<BookViewModel>>(booksDTO);

            return View(books);
        }

        [HttpPost]
        public ActionResult Add(BookViewModel book)
        {
            if (book.LanguagesIDs != null && book.LanguagesIDs.Length != 0)
            {
                foreach (var languageId in book.LanguagesIDs)
                {
                    var lang = book.Languages.Where(x => x.Value.Equals(languageId.ToString())).FirstOrDefault();
                    if (lang != null)
                    {
                        lang.Selected = true;
                    }
                }
            }

            var selectedLanguages = book.Languages.Where(x => x.Selected).Select(x => new LanguageDTO() { Id = int.Parse(x.Value), Name = x.Text }).ToList();
            var bookDto = new BookDTO
            {
                Author = book.Author,
                Created = book.Created,
                DeliveryRequred = book.DeliveryRequred,
                Description = book.Description,
                Genre = book.Genre,
                IsPaper = book.IsPaper,
                Title = book.Title,
                Id = book.Id,
                Languages = selectedLanguages
            };
            bookService.Add(bookDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            bookService.Remove(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var book = bookService.Get(id);
            if (book == null)
                return HttpNotFound();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookViewModel>()).CreateMapper();
            var bookView = mapper.Map<BookDTO, BookViewModel>(book);
            return View(bookView);
        }

        [HttpPost]
        public ActionResult Edit(BookViewModel book)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookViewModel, BookDTO>()).CreateMapper();
            var bookDAL = mapper.Map<BookViewModel, BookDTO>(book);
            bookService.Change(bookDAL);
            return RedirectToAction("Index");
        }
    }
}

