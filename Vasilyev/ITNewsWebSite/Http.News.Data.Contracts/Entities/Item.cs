﻿using System;

namespace Http.News.Data.Contracts.Entities
{
    public class Item
    {
        public int Id { get; set; }

        public int ItemContentId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ItemContent ItemContent { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int Rating { get; set; }

        public int TotalRaters { get; set; }

        public double AverageRating { get; set; }
    }
}
