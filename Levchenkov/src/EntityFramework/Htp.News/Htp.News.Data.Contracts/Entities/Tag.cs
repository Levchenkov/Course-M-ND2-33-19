using System.Collections.Generic;

namespace Htp.News.Data.Contracts.Entities
{
    public class Tag
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}