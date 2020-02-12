using System;
using System.Collections.Generic;
using Http.News.Data.Contracts.Entities;
using Http.News.Domain.Contracts.Dtos;
using Http.News.Domain.Contracts.ViewModels;

namespace Http.News.Domain.Services
{
    public interface INewsService
    {
        List<CategorySummaryDto> GetCategoryForMenu();
        Category GetCategoryById(int id);
        Item GetItemById(int id);
        IEnumerable<ItemSummaryDto> GetItemSummaries();
        IEnumerable<ItemSummaryDto> GetHottestItems(int numOfItemOnHomePage);
        IEnumerable<ItemSummaryDto> GetLatestItems(int numOfItemOnHomePage);
        IEnumerable<ItemSummaryDto> GetItemsByCategoryId(int categoryId);
        ItemDetailsDto GetItemDetails(int itemId, int catId, string userId);
        HomePageViewModel BuildHomePageViewModel(int p);
        SearchPageViewModel BuildSearchPageViewModel(string searchString);
        SearchPageViewModel BuildSearchPageViewModelByTag(string tag);
        ItemDetailsViewModel BuildItemDetailsViewModel(int categoryId, int itemId, string userId);
        CategoryPageViewModel BuildCategoryPageViewModel(int id);
        ItemDetailsDto IncrementArticleRating(double score, int id);
        void SetLike(int itemId, string userId, bool islike);
        void Add(ItemDetailsDto viewModel);
        void AddCategory(string catname, string username);
        void Save(ItemDetailsDto viewModel);
        void Save(ItemDetailsViewModel viewModel);
        ItemDetailsViewModel IncrementArticleRating(ItemDetailsViewModel viewModel);
        ItemDetailsDto GetItemDtoById(int itemId, string userId);
        IEnumerable<ItemSummaryDto> GetAllItems();
        List<Tag> GetAllTags();
    }
}