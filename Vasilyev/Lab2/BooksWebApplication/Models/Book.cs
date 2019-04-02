using BooksWebApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Web.Mvc;

namespace Models
{
    [DataContract]
    public class Book
    {
        public Book()
        {

        }

        public Book(int id, string title)
        {
            Id = id;
            Title = title;
        }

        [DataMember]
        public int Id
        {
            get;
            set;
        }

        [DataMember]
        [Display(Name = "Title")]
        public string Title
        {
            get;
            set;
        }

        [DataMember]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public Genre Genre { get; set; }

        public IList<SelectListItem> AvailableGenres { get; set; }

        [DataMember]
        public bool IsPaper { get; set; }

        [DataMember]        
        public int[] Languages { get; set; }

        public IList<SelectListItem> AvailableLanguages { get; set; }

        [DataMember]
        [Display(Name = "Delivery required")]
        public bool DeliveryRequired { get; set; }
    }
}