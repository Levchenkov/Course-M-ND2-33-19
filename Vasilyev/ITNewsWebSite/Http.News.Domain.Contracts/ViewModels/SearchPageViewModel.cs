using Http.News.Domain.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http.News.Domain.Contracts.ViewModels
{
    public class SearchPageViewModel : FrontPageViewModelBase
    {
        public SearchPageViewModel()
        {
            this.SearchItems = new List<ItemSummaryDto>();
        }

        public List<ItemSummaryDto> SearchItems { get; set; }
    }
}
