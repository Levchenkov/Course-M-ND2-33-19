using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication16.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }

        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public bool IsCommentable { get; set; }

        public Category Category { get; set; }

        public IList<SelectListItem> AvailableCategories { get; set; }

        public PostVersion Version { get; set; }

        public int[] Tags { get; set; }

        public IList<SelectListItem> AvailableTags { get; set; }

        public DateTime Created { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}