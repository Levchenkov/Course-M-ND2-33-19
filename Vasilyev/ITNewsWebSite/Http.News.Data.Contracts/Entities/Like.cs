using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http.News.Data.Contracts.Entities
{
    public class Like
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ItemId { get; set; }
        public bool IsLike { get; set; }
        public DateTime DateTime { get; set; }
    }
}
