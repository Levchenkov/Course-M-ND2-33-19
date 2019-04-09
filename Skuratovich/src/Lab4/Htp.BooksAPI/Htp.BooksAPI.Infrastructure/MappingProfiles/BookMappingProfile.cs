using AutoMapper;
using Htp.BooksAPI.Data.Contracts.Entities;
using Htp.BooksAPI.Domain.Contracts.ViewModels;

namespace Htp.BooksAPI.Infrastructure.MappingProfiles
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            MapBookToBookViewModel();
            MapBookViewModelToBook();
        }

        private void MapBookToBookViewModel()
        {
            CreateMap<Book, BookViewModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest => dest.Created, c => c.MapFrom(src => src.Created))
                .ForMember(dest => dest.CreatedByUserID, c => c.MapFrom(src => src.CreatedBy.Id))
                .ForMember(dest => dest.CreatedByUserName, c => c.MapFrom(src => src.CreatedBy.UserName))
                .ForMember(dest => dest.Updated, c => c.MapFrom(src => src.Updated))
                .ForMember(dest => dest.UpdatedByUserID, c => c.MapFrom(src => src.UpdatedBy.Id))
                .ForMember(dest => dest.UpdatedByUserName, c => c.MapFrom(src => src.UpdatedBy.UserName))

                //.ForMember(dest => dest.RowVersion, c => c.MapFrom(src => src.RowVersion))
                //.ForMember(dest => dest.LongRowVersion, c => c.MapFrom(src => src.LongRowVersion))
                .ForAllOtherMembers(c => c.Ignore());
        }

        private void MapBookViewModelToBook()
        {
            CreateMap<BookViewModel, Book>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                //.ForMember(dest => dest.Created, c => c.MapFrom(src => src.Created))
                //.ForPath(dest => dest.CreatedBy.Id, c => c.MapFrom(src => src.CreatedByUserID))
                //.ForMember(dest => dest.Updated, c => c.MapFrom(src => src.Updated))
                //.ForPath(dest => dest.UpdatedBy.Id, c => c.MapFrom(src => src.UpdatedByUserID))

                //.ForMember(dest => dest.RowVersion, c => c.MapFrom(src => src.RowVersion))
                //.ForMember(dest => dest.LongRowVersion, c => c.MapFrom(src => src.LongRowVersion))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}
