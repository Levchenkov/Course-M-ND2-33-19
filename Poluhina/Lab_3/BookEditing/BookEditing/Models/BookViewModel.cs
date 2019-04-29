using BookEditing.BLL.DTO;
using BookEditing.BLL.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookEditing.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public string Genre { get; set; }
        public bool IsPaper { get; set; }
        public bool DeliveryRequred { get; set; }
        public List<SelectListItem> Languages { get; set; }
        public int[] LanguagesIDs { get; set; }

        public BookViewModel()
        {
            var repository= DependencyResolver.Current.GetService<IBookService<BookDTO>>();
            var bLanguages = repository.GetLanguageDTO();
            var langs = bLanguages.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
            this.Languages = langs;
        }
    }
}