using Lab.Library.Data.Contracts.Entities;
using Lab.Library.Domain.Contracts.ViewModels;
using Profile =  AutoMapper.Profile;

namespace Lab.Library.Infrastructure.MappingProfiles
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
                .ForMember(dest=>dest.Id, c=>c.MapFrom(src=>src.Id))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest => dest.Author, c => c.MapFrom(src => src.Author))
                .ForMember(dest => dest.Created, c => c.MapFrom(src => src.Created))
                .ForPath(dest => dest.Genre.GenreNamEnum, c => c.MapFrom(src => src.Genre.GenreNamEnum))
                .ForMember(dest => dest.IsPaper, c => c.MapFrom(src => src.IsPaper))
                .ForMember(dest => dest.Languages, c => c.MapFrom(src => src.Languages))
                .ForMember(dest => dest.DeliveryRequired, c => c.MapFrom(src => src.DeliveryRequired))
                .ForAllOtherMembers(c=>c.Ignore());

        }

        private void MapBookViewModelToBook()
        {
            CreateMap<BookViewModel, Book>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest => dest.Author, c => c.MapFrom(src => src.Author))
                .ForMember(dest => dest.Created, c => c.MapFrom(src => src.Created))
                .ForPath(dest => dest.Genre.GenreNamEnum, c => c.MapFrom(src => src.Genre.GenreNamEnum))
                .ForMember(dest => dest.IsPaper, c => c.MapFrom(src => src.IsPaper))
                .ForMember(dest => dest.Languages, c => c.MapFrom(src => src.Languages))
                .ForMember(dest => dest.DeliveryRequired, c => c.MapFrom(src => src.DeliveryRequired))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}
