using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Http.News.Data.Contracts.Entities;
using Http.News.Domain.Contracts.Dtos;
using Http.News.Domain.Contracts.ViewModels;
using Http.News.Domain.Services;
using ITNewsWeb.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ITNewsWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsService _newsService;

        public HomeController(INewsService newsService)
        {
            _newsService = newsService;
        }

        //[Authorize]
        //public ActionResult Index()
        //{
        //    IList<string> roles = new List<string> { "Роль не определена" };
        //    ApplicationUserManager userManager = HttpContext.GetOwinContext()
        //        .GetUserManager<ApplicationUserManager>();
        //    ApplicationUser user = userManager.FindByEmail(User.Identity.Name);
        //    if (user != null)
        //        roles = userManager.GetRoles(user.Id);
        //    return View(roles);
        //}

        public ActionResult Index()
        {
            var viewModel = _newsService.BuildHomePageViewModel(20);
            return View(viewModel);
        }

        public ActionResult Search(string searchString)
        {
            string str = HttpUtility.UrlDecode(searchString);
            if (string.IsNullOrEmpty(str))
            {
                RedirectToAction("Index");
            }
            var viewModel = _newsService.BuildSearchPageViewModel(str);
            return View(viewModel);
        }

        [Route("Home/Details/{title?}/{categoryId:int}/{itemId:int}")]
        public ActionResult Details(int categoryId, int itemId, string title = null)
        {
            ItemDetailsViewModel viewModel = _newsService.BuildItemDetailsViewModel(categoryId, itemId, User.Identity.GetUserId());

            return View(viewModel);
        }

        [Route("Home/Category/{name}/{id:int}")]
        public ActionResult Category(string name, int id)
        {
            var viewModel = _newsService.BuildCategoryPageViewModel(id);
            return View(viewModel);
        }

        [Authorize(Roles = "admin")]
        public ActionResult AddCategory()
        {
            var viewModel = new Category();
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult AddCategory(Category category)
        {
            _newsService.AddCategory(category.Name, User.Identity.GetUserName());
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult SetRating(int itemId, double ratingValue)
        {
            if (Request.Cookies["rating" + itemId] != null)
            {
                ViewBag.Message = "You have already rated this article";
                return null;
            }
            Response.Cookies["rating" + itemId].Value = DateTime.Now.ToString();
            Response.Cookies["rating" + itemId].Expires = DateTime.Now.AddYears(1);
            var viewModel = _newsService.IncrementArticleRating(ratingValue, itemId);
            return Json(new { Result = viewModel.AverageRating }); 
        }

        [Authorize]
        [HttpPost]
        public ActionResult SetLike(int itemId)
        {
            var viewModel = _newsService.GetItemDtoById(itemId, User.Identity.GetUserId());
            
            _newsService.SetLike(itemId, User.Identity.GetUserId(), !viewModel.IsLiked);
            return Json(new { IsLiked = !viewModel.IsLiked, HasError = false });
        }

        [Authorize]
        [HttpPost]
        public ActionResult Details(ItemDetailsDto viewModel, double score)
        {
            var id = viewModel.Id;
            var catid = viewModel.CategoryId;
            if (Request.Cookies["rating" + id] != null)
            {
                ViewBag.Message = "You have already rated this article";
                return View(_newsService.BuildItemDetailsViewModel(catid, id, User.Identity.GetUserId()));
            }

            Response.Cookies["rating" + +id].Value = DateTime.Now.ToString();
            Response.Cookies["rating" + id].Expires = DateTime.Now.AddYears(1);
            viewModel = _newsService.IncrementArticleRating(score, id);
            return View(_newsService.BuildItemDetailsViewModel(catid, id, User.Identity.GetUserId()));
        }

        public JsonResult OnPostFile()
        {
            HttpPostedFileBase file = Request.Files[0];
                                                  
            int fileSize = file.ContentLength;
            string fileName = file.FileName;
            string mimeType = file.ContentType;
            Stream fileContent = file.InputStream;
            file.SaveAs(Server.MapPath("~/") + fileName);

            var filePath = Path.Combine(Server.MapPath("~/Upload/img/"), fileName);
            file.SaveAs(filePath);

            return Json(new { fileName = "/Upload/img/" + fileName });
            }

        [Authorize(Roles = "admin, writer")]
        public ActionResult Create()
        {
            var viewModel = new ItemDetailsDto();
            PrepareView(viewModel);
            ViewBag.Title = "Create";
            return View(viewModel);
        }

        [Authorize(Roles = "admin, writer")]
        public ActionResult Edit(int id)
        {
            var viewModel = _newsService.GetItemDtoById(id, User.Identity.GetUserId());
            PrepareView(viewModel);
            ViewBag.Title = "Edit";
            return View("Create", viewModel);
        }

        private void PrepareView(ItemDetailsDto viewModel)
        {
            viewModel.CatList = new List<SelectListItem>();
            var cat = _newsService.GetCategoryForMenu();
            for (int i = 0; i < cat.Count; i++)
            {
                viewModel.CatList.Add(new SelectListItem { Value = ( i + 1 ).ToString(), Text = cat.ElementAt(i).Name });
            }
        }

        [Authorize(Roles = "admin, writer")]
        [HttpPost]
        public ActionResult Create(ItemDetailsDto viewModel)
        {
            try
            {
                viewModel.CreatedBy = User.Identity.Name;
                viewModel.CreatedDate = DateTime.Now;
                var catid = viewModel.CategoryId;
                string filename = Path.GetFileNameWithoutExtension(viewModel.ImageFile.FileName);
                string extention = Path.GetExtension(viewModel.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extention;
                viewModel.SmallImageUrl = viewModel.BigImageUrl = viewModel.MediumImageUrl = "/Upload/img/" + filename;
                _newsService.Add(viewModel);
                filename = Path.Combine(Server.MapPath("~/Upload/img/"), filename);
                viewModel.ImageFile.SaveAs(filename);
                //NewsService.Save(viewModel);
                var id = _newsService.GetItemsByCategoryId(catid).OrderBy(x => x.ItemId).Last().ItemId;
                return RedirectToAction("Details", "Home", new {categoryId = catid, itemId = id});
            }
            catch (Exception e)
            {
                return View();
            }
        }

        [Authorize(Roles = "admin, writer")]
        [HttpPost]
        public ActionResult Edit(ItemDetailsDto viewModel)
        {
            try
            {
                viewModel.ModifiedBy = User.Identity.Name;
                viewModel.ModifiedDate = DateTime.Now;
                var catid = viewModel.CategoryId;
                if(viewModel.ImageFile != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(viewModel.ImageFile.FileName);
                    string extention = Path.GetExtension(viewModel.ImageFile.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extention;
                    viewModel.SmallImageUrl = viewModel.BigImageUrl = viewModel.MediumImageUrl = "/Upload/img/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Upload/img/"), filename);
                    viewModel.ImageFile.SaveAs(filename);
                }
                _newsService.Save(viewModel);
                var id = _newsService.GetItemsByCategoryId(catid).OrderBy(x => x.ItemId).Last().ItemId;
                return RedirectToAction("Details", "Home", new { categoryId = catid, itemId = id });
            }
            catch (Exception e)
            {
                return View();
            }
        }

        //[Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult GetAllTags()
        {
            var tags = _newsService.GetAllTags();

            var tagsViewModel = tags.Select(x => new TagViewModel
            {
                Text = x.Text,
                Link = Url.Action("Search", "Home", new { searchString = x.Text })
            });

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(tagsViewModel, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }),
                ContentEncoding = Encoding.UTF8
            };
        }
    }
}