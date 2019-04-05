using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Course.Library.Data.Contracts.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual Author Author { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        [JsonIgnore]
        public virtual Genre Genre { get; set; }
        public bool IsPaper { get; set; }
        [JsonIgnore]
        public virtual ICollection<Language> Languages { get; set; }
        public bool DeliveryRequired { get; set; }
    }
}
