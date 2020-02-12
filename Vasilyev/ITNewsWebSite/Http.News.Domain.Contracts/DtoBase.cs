using System;
using System.ComponentModel;

namespace Http.News.Domain.Contracts
{
    public class DtoBase
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Created Date")]
        public DateTime? CreatedDate { get; set; }

        [DisplayName("Created By")]
        public string CreatedBy { get; set; }

        [DisplayName("Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayName("Modified Date")]
        public DateTime? ModifiedDate { get; set; }

        [DisplayName("Rating")]
        public double Rating { get; set; }

        [DisplayName("Total Raters")]
        public int TotalRaters { get; set; }

        [DisplayName("Average Rating")]
        public double AverageRating { get; set; }

        [DisplayName("Likes")]
        public double TotalLikes { get; set; }

        [DisplayName("Dislikes")]
        public double TotalDislikes { get; set; }
    }
}