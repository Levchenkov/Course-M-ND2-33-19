using AutoMapper;
using Htp.News.Data.Contracts;
using Htp.News.Data.Contracts.Entities;
using Htp.News.Domain.Contracts;
using Htp.News.Domain.Contracts.ViewModels;

namespace Htp.News.Domain.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public PostViewModel Get(int id)
        {
            Post post = unitOfWork.Get<Post>(id);

            var result = Mapper.Map<PostViewModel>(post);
            return result;
        }
    }
}
