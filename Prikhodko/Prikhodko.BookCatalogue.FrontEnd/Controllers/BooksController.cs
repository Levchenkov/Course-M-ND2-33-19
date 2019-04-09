using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Prikhodko.BookCatalogue.FrontEnd.Filters.AuthentificationFilters;
using Prikhodko.BookCatalogue.FrontEnd.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Prikhodko.BookCatalogue.FrontEnd.Services.Contracts;

namespace Prikhodko.BookCatalogue.FrontEnd.Controllers
{
    [Authenticate]
    public class BooksController : Controller
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string externalResourceLink = "http://localhost:50597/";
        private readonly IBookService bookService;


        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new BookViewModel();
            ViewBag.Languages = GetLanguageViewModels();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BookViewModel input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            if(input.AvailableLanguages == null)
            {
                input.AvailableLanguages = new List<string>();
            }
            var post = new StringContent(JsonConvert.SerializeObject(input));
            httpClient.PostAsync($"{externalResourceLink}Book", post);
            return RedirectToAction("ShowCollection");
        }
        
        public ActionResult Edit(int id)
        {
            var model = bookService.Get(id);
            ViewBag.Languages = GetLanguageViewModels();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BookViewModel input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            if (input.AvailableLanguages == null)
            {
                input.AvailableLanguages = new List<string>();
            }
            bookService.Update(input);
            return RedirectToAction("ShowCollection");
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
        
        [HttpGet]
        public async Task<ActionResult> ShowCollection()
        {
            var model = await httpClient.GetAsync($"{externalResourceLink}Book");
            return View(model);
        }

        private IEnumerable<LanguageViewModel> GetLanguageViewModels()
        {
            var languagesHttp = httpClient.GetAsync($"{externalResourceLink}Language").ConfigureAwait(false).GetAwaiter().GetResult();
            var languageViewModels = JsonConvert.DeserializeObject<List<LanguageViewModel>>(languagesHttp.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult());
            return languageViewModels;
        }
    }
}
