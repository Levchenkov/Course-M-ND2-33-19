using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Http.News.Domain.Contracts.Dtos;
using Http.News.Domain.Contracts.ViewModels;

namespace Http.News.Infrastructure
{
    public interface INewsUnitOfWork
    {
        //#region admin page

        //#region category

        //IEnumerable<CategorySummaryDto> GetCategorySummaries();

        //CategorySummaryDto GetCategoryById(int id);

        //CategorySummaryViewModel GetCategoryPaging(int pageSize, int page);

        //void SaveCategory(CategorySummaryDto dto);

        //void DeleteCategory(int id);

        //#endregion

        //#region item

        //ItemSummaryViewModel GetItemSummaryPaging(int pageSize, int page);

        //ItemDetailsDto GetItemById(int id);

        //void SaveItem(ItemDetailsDto dto);

        //void DeleteItem(int id);

        //#endregion

        //#endregion

        #region front-end page

        HomePageViewModel BuildHomePageViewModel(int numOfItemOnHomePage);

        CategoryPageViewModel BuildCategoryPageViewModel(int id);

        ItemDetailsViewModel BuildItemDetailsViewModel(int categoryId, int itemId);

        CategoryMenuViewModel GetCategoryMenu(int id);

        #endregion
    }
}
