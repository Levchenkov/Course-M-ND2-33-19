using System;
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
            this.Languages = new List<SelectListItem>()
            {
            new SelectListItem { Text = "Russian" , Value = "0"},
            new SelectListItem { Text = "Deutsch" , Value = "1"},
            new SelectListItem { Text = "English" , Value = "2"},
            new SelectListItem { Text = "Spanish" , Value = "3"},
            };
        }
    }
}