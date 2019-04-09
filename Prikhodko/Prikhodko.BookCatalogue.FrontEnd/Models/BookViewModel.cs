using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prikhodko.BookCatalogue.FrontEnd.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AuthorViewModel Author { get; set; }
        private DateTime? dateOfIssue = null;
        public DateTime? DateOfIssue
        {
            get
            {
                return dateOfIssue;
            }
            set
            {
                dateOfIssue = value <= DateTime.MinValue ? DateTime.MinValue.Date.ToUniversalTime() : value;
            }
        }
        public Genre Genre { get; set; }
        public bool IsPaper { get; set; }
        public DeliveryOptions DeliveryOption { get; set; }
        public ICollection<DeliveryOptions> AvailableDeliveryOptions { get; set; }
        public ICollection<string> AvailableLanguages { get; set; }

        public BookViewModel()
        {
            AvailableDeliveryOptions = new List<DeliveryOptions>
            {
                DeliveryOptions.Takeaway,
                DeliveryOptions.Post,
                DeliveryOptions.Courier
            };
        }

    }
}