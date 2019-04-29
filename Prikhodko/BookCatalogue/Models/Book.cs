using System;
using System.Collections.Generic;

namespace Prikhodko.BookCatalogue.Data.Contracts.Models
{
    public class Book
    {
        public virtual int BookId { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual Author Author { get; set; }
        public virtual DateTime DateOfIssue { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual bool IsPaper { get; set; }
        public virtual DeliveryOptions DeliveryOption { get; set; }
        public virtual ICollection<Language> AvailableLanguages { get; set; }
        public virtual ICollection<BookChange> BookChanges { get; set; }


        public override string ToString()
        {
            return $"ID: {BookId}; Name: \"{Title}\"; by {Author} ({DateOfIssue})";
        }
    }
}
