using System.Collections.Generic;
using Http.News.Domain.Contracts.Dtos;

namespace Http.News.Domain.Services
{
    public interface ICategoryService
    {
        List<CategorySummaryDto> GetCategoryForMenu();
        CategorySummaryDto GetCategoryById(int id);
    }
}