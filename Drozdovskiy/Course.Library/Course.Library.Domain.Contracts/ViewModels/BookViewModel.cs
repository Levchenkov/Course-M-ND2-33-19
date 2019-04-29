using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course.Library.Data.Contracts.Entities;

namespace Course.Library.Domain.Contracts.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int AuthorId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public List<Language> Languages { get; set; }
        public bool DeliveryRequired { get; set; }
        public bool IsPaper { get; set; }
        public string Genre { get; set; }
        public List<string> tempLanguages { get; set; }
    }
}
