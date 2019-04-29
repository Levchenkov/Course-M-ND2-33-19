using System;
using System.Net;
using System.Web.Mvc;
using Prikhodko.BookCatalogue.Service.Contracts.Models;
using Prikhodko.BookCatalogue.Service.Contracts.Interfaces;

namespace Prikhodko.BookCatalogue.PL.Controllers
{
    [RoutePrefix("languages")]
    public class APILanguagesController : Controller
    {
        private readonly ILanguageService languageService;

        public APILanguagesController(ILanguageService languageService)
        {
            this.languageService = languageService;
        }

        [Route]
        [HttpGet]
        public ActionResult GetAll()
        {
            var model = languageService.GetAll();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult Get(int id)
        {
            var model = languageService.Get(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [Route]
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Add(LanguageViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            languageService.Add(model);
            return new HttpStatusCodeResult(HttpStatusCode.Created);
        }

        [Route("{id}")]
        [HttpPut]
        public ActionResult Update(int id, LanguageViewModel input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (id < 0 || input.LanguageId < 0 || string.IsNullOrEmpty(input.Name) || string.IsNullOrEmpty(input.Code))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = languageService.Get(id);

            if (model == null)
            {
                Add(input);
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }

            else
            {
                input.LanguageId = model.LanguageId;
                languageService.Update(input);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
        }

        [Route("{id}")]
       // [Authorize(Roles = "Admin")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            languageService.Remove(id);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}