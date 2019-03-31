using System.Collections.Generic;

namespace Htp.News.Data.Contracts.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public Profile Profile { get; set; }

        public ICollection<Post> Posts { get; set; }

        public Address Address { get; set; }
    }
}