namespace Http.News.Domain.Contracts.Dtos
{
    public class CategorySummaryDto : DtoBase
    {
        public string Name { get; set; }

        public bool IsCurrentPage { get; set; }
    }
}