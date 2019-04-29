using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lab.Library.Data.Contracts.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }

        [JsonIgnore]
        public virtual Genre Genre { get; set; }

        public bool IsPaper { get; set; }

        [JsonIgnore]
        public virtual ICollection<Language> Languages { get; set; }

        public bool DeliveryRequired { get; set; }
    }
}
