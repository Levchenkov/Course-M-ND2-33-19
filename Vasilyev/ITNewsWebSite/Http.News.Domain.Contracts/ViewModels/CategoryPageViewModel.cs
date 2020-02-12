namespace Http.News.Domain.Contracts.ViewModels
{
    using System.Collections.Generic;

    using Http.News.Domain.Contracts.Dtos;

    public class CategoryPageViewModel : FrontPageViewModelBase
    {
        public CategoryPageViewModel()
        {
            this.RowItems = new Dictionary<int, List<ItemSummaryDto>>();
        }

        public int CategoryId { get; set; }

        public Dictionary<int, List<ItemSummaryDto>> RowItems { get; private set; }

        public void ItemsConverting(List<ItemSummaryDto> sources)
        {
            var counter = 1;
            var row = new List<ItemSummaryDto>();

            if (sources.Count <= 4)
            {
                this.RowItems.Add(counter, sources);
            }
            else
            {
                foreach (var item in sources)
                {
                    row.Add(item);
                    if (counter%4 != 0)
                    {
                        this.RowItems.Add(counter, row);
                        row = new List<ItemSummaryDto>();
                    }
                    counter++;
                }
            }
        }
    }
}