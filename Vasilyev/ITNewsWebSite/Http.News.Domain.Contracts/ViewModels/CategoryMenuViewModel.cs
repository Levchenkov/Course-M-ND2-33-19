namespace Http.News.Domain.Contracts.ViewModels
{
    using System.Collections.Generic;

    using Http.News.Domain.Contracts.Dtos;

    public class CategoryMenuViewModel
    {
        public CategoryMenuViewModel()
        {
            this.Categories = new List<CategorySummaryDto>();
        }

        public IEnumerable<CategorySummaryDto> Categories { get; set; }
    }
}