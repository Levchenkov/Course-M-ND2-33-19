namespace Http.News.Domain.Contracts.ViewModels
{
    using Http.News.Domain.Contracts.Dtos;

    public class ItemDetailsViewModel : FrontPageViewModelBase
    {
        public ItemDetailsViewModel()
        {
            this.ItemDetails = new ItemDetailsDto();
        }
        
        public ItemDetailsDto ItemDetails { get; set; }

        public string CategoryName { get; set; }
    }
}