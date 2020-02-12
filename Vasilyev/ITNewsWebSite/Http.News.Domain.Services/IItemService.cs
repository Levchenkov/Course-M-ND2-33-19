using System.Collections.Generic;
using Http.News.Domain.Contracts.Dtos;

namespace Http.News.Domain.Services
{
    public interface IItemService
    {
        IEnumerable<ItemSummaryDto> GetItemSummaries();
        IEnumerable<ItemSummaryDto> GetHottestItems(int numOfItemOnHomePage);
        IEnumerable<ItemSummaryDto> GetLatestItems(int numOfItemOnHomePage);
        IEnumerable<ItemSummaryDto> GetItemsByCategoryId(int categoryId);
        ItemDetailsDto GetItemDetails(int itemId);
    }
}