using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http.News.Data.Contracts.Entities
{
    public class Tag
    {
        [Key]
        [Index(IsUnique = true)]
        public string Text { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
