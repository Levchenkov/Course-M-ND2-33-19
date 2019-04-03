using Htp.News.Data.Contracts.Entities;
using Htp.News.Domain.Contracts.ViewModels;
using Profile = AutoMapper.Profile;

namespace Htp.News.Infrastructure.MappingProfiles
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            MapPostToPostViewModel();
            MapPostViewModelToPost();
        }

        private void MapPostToPostViewModel()
        {
            CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.LongVersion, c => c.MapFrom(src => src.LongVersion))
                .ForMember(dest => dest.AuthorId, c => c.MapFrom(src => src.Author.Id))
                .ForMember(dest => dest.AuthorUserName, c => c.MapFrom(src => src.Author.UserName))
                .ForAllOtherMembers(c => c.Ignore());
        }

        private void MapPostViewModelToPost()
        {
            CreateMap<PostViewModel, Post>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.LongVersion, c => c.MapFrom(src => src.LongVersion))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}
