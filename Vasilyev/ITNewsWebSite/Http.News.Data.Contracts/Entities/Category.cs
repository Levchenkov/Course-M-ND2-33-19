using System;
using System.Collections.Generic;

namespace Http.News.Data.Contracts.Entities
{
    public sealed class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
