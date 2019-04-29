using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Lab3.DAL.Contracts.Entities;

namespace Lab3.BLL.Contracts.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public int GenreID { get; set; }
        public Genres GenreName { get; set; }
        
        public bool IsPaper { get; set; }
        public int DeliveryID { get; set; }
        public TypesofDelivery DeliveryType { get; set; }

        public int[] LanguagesID { get; set; }
        public Langua[] LanguagesNames { get; set; }

        public IList<SelectListItem> GenresAvailable { get; set; }
              

        public IList<SelectListItem> LanguageAvailable { get; set; }
        public long LongVersion { get; set; }


    }
}
