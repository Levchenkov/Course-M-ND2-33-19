using Htp.Library.Data.Contracts.Entities;
using Htp.Library.Domain.Contracts.ViewModels;
using Profile = AutoMapper.Profile;

namespace Htp.Library.Infrastructure.MappingProfiles
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
                    .ForMember(dest => dest.Author, c => c.MapFrom(src => src.Author))
                    .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                    .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Created, c => c.MapFrom(src => src.Created))
                    .ForMember(dest => dest.Genre, c => c.MapFrom(src => src.Genre.ToString()))
                    .ForMember(dest => dest.IsPaper, c => c.MapFrom(src => src.IsPaper))
                    .ForMember(dest => dest.Language, c => c.MapFrom(src => src.Language.ToString()))
                    .ForMember(dest => dest.DeliveryRequired, c => c.MapFrom(src => src.DeliveryRequired))
                    .ForAllOtherMembers(c => c.Ignore());
        }

        private void MapBookViewModelToBook()
        {
            CreateMap<BookViewModel, Book>()
                    .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Author, c => c.MapFrom(src => src.Author))
                    .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                    .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Created, c => c.MapFrom(src => src.Created))
                    .ForMember(dest => dest.Genre, c => c.MapFrom(src => GetBookEnum(src.Genre)))
                    .ForMember(dest => dest.IsPaper, c => c.MapFrom(src => src.IsPaper))
                    .ForMember(dest => dest.Language, c => c.MapFrom(src => GetLangEnum(src.Language)))
                    .ForMember(dest => dest.DeliveryRequired, c => c.MapFrom(src => src.DeliveryRequired))
                    .ForAllOtherMembers(c => c.Ignore());
        }

        private Book.Genres GetBookEnum(string str)
        {
            if (str == "Crime")
                return (Book.Genres)1;
            if (str == "Detective")
                return (Book.Genres)2;
            if (str == "Science")
                return (Book.Genres)3;
            if (str == "Fantasy")
                return (Book.Genres)4;
            if (str == "Romance")
                return (Book.Genres)5;
            else
                return 0;
        }

        private Book.Languages GetLangEnum(string[] str)
        {
            int a= 0;

            foreach (var item in str)
            { 
                if (item == "None")
                    return 0;
                else
                if (item == "Russian")
                    a += 1;
                else
                if (item == "English")
                    a += 2;
                else
                if (item == "France")
                    a += 4;
            }
            return (Book.Languages)a;
        }
    }
}
