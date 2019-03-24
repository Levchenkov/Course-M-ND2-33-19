using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBookLibrary.Models.LibraryModels
{
    public class BookViewModel
    {
        public BookViewModel(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Description = book.Description;
            Author = book.Author;
            Created = book.Created;
            Genre = book.Genre;
            IsPaper = book.IsPaper;
            Languages = book.Languages?.Select(x => new LanguageViewModel
                                                   {Id = x.Id, Dialect = x.Dialect})
                        ?? new List<LanguageViewModel>();
            DeliveryRequired = book.DeliveryRequired;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public Genre Genre { get; set; }
        public bool IsPaper { get; set; }
        public IEnumerable<LanguageViewModel> Languages { get; set; }
        public bool DeliveryRequired { get; set; }
    }
}