using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Http.News.Domain.Contracts.Dtos
{
    public class ItemDetailsDto : DtoBase
    {
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Short description")]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [DisplayName("Content")]
        public string Content { get; set; }

        [DisplayName("Upload image")]
        public string SmallImageUrl { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public string MediumImageUrl { get; set; }

        public string BigImageUrl { get; set; }

        [DisplayName("Number of views")]
        public long NumOfView { get; set; }

        public List<SelectListItem> CatList { get; set; }

        public bool IsLiked { get; set;}
    }
}