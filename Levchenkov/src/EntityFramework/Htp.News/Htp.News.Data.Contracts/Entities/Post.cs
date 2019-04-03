using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Htp.News.Data.Contracts.Entities
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        public long LongVersion
        {
            get => BitConverter.ToInt64(Version, 0);
            set => Version = BitConverter.GetBytes(value);
        }
    }
}
