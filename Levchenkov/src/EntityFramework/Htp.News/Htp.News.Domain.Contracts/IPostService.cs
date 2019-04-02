using Htp.News.Domain.Contracts.ViewModels;

namespace Htp.News.Domain.Contracts
{
    public interface IPostService
    {
        PostViewModel Get(int id);
        void Save(PostViewModel viewModel);
    }
}
