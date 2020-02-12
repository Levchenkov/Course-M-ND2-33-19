using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Http.News.Data.Contracts.Entities
{
    public class Item
    {
        public int Id { get; set; }

        public int ItemContentId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ItemContent ItemContent { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public double Rating { get; set; }

        public int TotalRaters { get; set; }

        public int TotalLikes { get; set; }

        public int TotalDislikes { get; set; }

        public double AverageRating { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
