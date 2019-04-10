using System;

namespace Htp.Library.Domain.Contracts.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string Genre { get; set; }
        public bool IsPaper { get; set; }
        public string[] Language { get; set; }
        public bool DeliveryRequired { get; set; }
    }
}