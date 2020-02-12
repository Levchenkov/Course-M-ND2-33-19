using System.ComponentModel;

namespace Http.News.Domain.Contracts.Dtos
{
    public class ItemSummaryDto : DtoBase
    {
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [DisplayName("Category")]
        public string CategoryName { get; set; }

        [DisplayName("Id")]
        public int ItemId { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        public string AvatarImage { get; set; }

        public string ShortDescription { get; set; }
    }
}