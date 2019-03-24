using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBookLibrary.Models.LibraryModels
{
    //[Flags]
    //public enum Language
    //{
    //    English = 2,
    //    German = 4,
    //    France = 6,
    //    Russian = 8
    //}

    public class Language
    {
        public int Id { get; set; }
        public string Dialect { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}