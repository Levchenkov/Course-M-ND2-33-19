namespace Http.News.Domain.Contracts.ViewModels
{
    using System.Collections.Generic;

    using Http.News.Domain.Contracts.Dtos;

    public class CategorySummaryViewModel
    {
        public IEnumerable<CategorySummaryDto> Categories { get; set; }

        public int TotalPage { get; set; }
    }
}