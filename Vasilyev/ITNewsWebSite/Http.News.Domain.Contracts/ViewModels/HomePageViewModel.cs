namespace Http.News.Domain.Contracts.ViewModels
{
    using System.Collections.Generic;

    using Http.News.Domain.Contracts.Dtos;

    public class HomePageViewModel : FrontPageViewModelBase
    {
        public HomePageViewModel()
        {
            this.HottestItems = new List<ItemSummaryDto>();
            this.LatestItems = new List<ItemSummaryDto>();
        }

        public List<ItemSummaryDto> HottestItems { get; set; }

        public List<ItemSummaryDto> LatestItems { get; set; }
    }
}