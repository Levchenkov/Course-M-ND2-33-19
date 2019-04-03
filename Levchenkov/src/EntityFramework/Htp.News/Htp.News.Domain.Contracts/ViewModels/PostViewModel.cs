namespace Htp.News.Domain.Contracts.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string AuthorUserName { get; set; }
        public long LongVersion { get; set; }
    }
}
