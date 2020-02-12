using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http.News.Data.Contracts.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int ItemId { get; set; }
    }
}
