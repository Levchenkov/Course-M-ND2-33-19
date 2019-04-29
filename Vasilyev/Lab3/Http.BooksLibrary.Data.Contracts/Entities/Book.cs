using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Http.BooksLibrary.Data.Contracts.Entities
{
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

        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }

        public string Author { get; set; }

        public DateTime Created { get; set; }

        public Genre Genre { get; set; }

        //public IList<SelectListItem> AvailableGenres { get; set; }

        public bool IsPaper { get; set; }

        public int[] Languages { get; set; }

        //public IList<SelectListItem> AvailableLanguages { get; set; }
       
        public bool DeliveryRequired { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        public long LongVersion
        {
            get => BitConverter.ToInt64(Version, 0);
            set => Version = BitConverter.GetBytes(value);
        }
    }
}