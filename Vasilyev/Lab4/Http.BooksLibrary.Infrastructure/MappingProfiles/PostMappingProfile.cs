using AutoMapper;
using Http.BooksLibrary.Data.Contracts.Entities;
using Http.BooksLibrary.Domain.Contracts.ViewModels;

namespace Http.BooksLibrary.Infrastructure.MappingProfiles
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            MapBookToBookViewModel();
            MapBookViewModelToBook();
        }

        public void MapBookToBookViewModel()
        {
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Author, c => c.MapFrom(src => src.Author))
                .ForMember(dest => dest.Created, c => c.MapFrom(src => src.Created))
                .ForMember(dest => dest.Updated, c => c.MapFrom(src => src.Updated))
                .ForMember(dest => dest.CreatedBy, c => c.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.UpdatedBy, c => c.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.DeliveryRequired, c => c.MapFrom(src => src.DeliveryRequired))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest => dest.Genre, c => c.MapFrom(src => src.Genre))
                .ForMember(dest => dest.IsPaper, c => c.MapFrom(src => src.IsPaper))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.LongVersion, c => c.MapFrom(src => src.LongVersion))
                .ForMember(dest => dest.Languages, c => c.MapFrom(src => src.Languages))
                .ForAllOtherMembers(c => c.Ignore());
        }

        public void MapBookViewModelToBook()
        {
            CreateMap<BookViewModel, Book>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Author, c => c.MapFrom(src => src.Author))
                .ForMember(dest => dest.Created, c => c.MapFrom(src => src.Created))
                .ForMember(dest => dest.Updated, c => c.MapFrom(src => src.Updated))
                .ForMember(dest => dest.CreatedBy, c => c.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.UpdatedBy, c => c.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.DeliveryRequired, c => c.MapFrom(src => src.DeliveryRequired))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest => dest.Genre, c => c.MapFrom(src => src.Genre))
                .ForMember(dest => dest.IsPaper, c => c.MapFrom(src => src.IsPaper))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.LongVersion, c => c.MapFrom(src => src.LongVersion))
                .ForMember(dest => dest.Languages, c => c.MapFrom(src => src.Languages))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}