namespace Http.News.Domain.Contracts.ViewModels
{
    using System.Collections.Generic;

    using Http.News.Domain.Contracts.Dtos;

    public class ItemSummaryViewModel
    {
        public ItemSummaryViewModel()
        {
            this.Items = new List<ItemSummaryDto>();
        }

        public int TotalPage { get; set; }
        public IEnumerable<ItemSummaryDto> Items { get; set; }
    }
}