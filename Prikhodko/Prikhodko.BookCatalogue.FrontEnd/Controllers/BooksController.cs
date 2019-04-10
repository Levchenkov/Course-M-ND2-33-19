using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using Prikhodko.BookCatalogue.FrontEnd.Filters.AuthentificationFilters;
using Prikhodko.BookCatalogue.FrontEnd.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Xml.Schema;
using Prikhodko.BookCatalogue.FrontEnd.Services.Contracts;

namespace Prikhodko.BookCatalogue.FrontEnd.Controllers
{
    [Authenticate]
    public class BooksController : Controller
    {
        private readonly IFrontEndBookService frontEndBookService;
        private readonly IFrontEndLanguageService frontEndLanguageService;


        public BooksController(IFrontEndBookService frontEndBookService, IFrontEndLanguageService frontEndLanguageService)
        {
            this.frontEndBookService = frontEndBookService;
            this.frontEndLanguageService = frontEndLanguageService;
        }

        [HttpGet]
        public async Task<ActionResult> ShowCollection()
        {
            var model = await frontEndBookService.GetAll();
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var model = new BookViewModel();
            var languages = await GetLanguageViewModels();
            ViewBag.Languages = languages.Select(x => x.Code);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(BookViewModel input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            if(input.AvailableLanguages == null)
            {
                input.AvailableLanguages = new List<string>();
            }
            if (await frontEndBookService.Add(input))
            {
                return RedirectToAction("ShowCollection");
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
        }
        
        public async Task<ActionResult> Edit(int id)
        {
            var model = await frontEndBookService.Get(id);
            ViewBag.Languages = (await GetLanguageViewModels()).Select(x => x.Code);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(BookViewModel input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            if (input.AvailableLanguages == null)
            {
                input.AvailableLanguages = new List<string>();
            }
            var operationSuccessful = await frontEndBookService.Update(input);
            if (operationSuccessful)
            {
                return RedirectToAction("ShowCollection");
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (await frontEndBookService.Remove(id))
            {
                return RedirectToAction("ShowCollection");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }
        }

        private async Task<IEnumerable<LanguageViewModel>> GetLanguageViewModels()
        {
            var languageViewModels = await frontEndLanguageService.GetAll();
            return languageViewModels;
        }
    }
}
