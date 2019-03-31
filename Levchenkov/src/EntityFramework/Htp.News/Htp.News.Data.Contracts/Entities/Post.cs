using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Htp.News.Data.Contracts.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //public int UserId { get; set; }
        public User Author { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
