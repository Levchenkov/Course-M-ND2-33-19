using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookCatalogue;

namespace BookCataloguePL.Models
{
    public class BookViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
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
        public List<DeliveryOptions> AvailableDeliveryOptions { get; set; }
        public List<Languages> AvailableLanguages { get; set; }

        public BookViewModel()
        {
            AvailableLanguages = new List<Languages>
            {
                Languages.English,
                Languages.Russian,
                Languages.German,
                Languages.Italian,
                Languages.Chinese,
                Languages.French
            };

            AvailableDeliveryOptions = new List<DeliveryOptions>
            {
                DeliveryOptions.Takeaway,
                DeliveryOptions.Post,
                DeliveryOptions.Courier
            };
        }

    }
}