using AutoMapper;
using Prikhodko.BookCatalogue.Service.Contracts.Models;
using Prikhodko.BookCatalogue.Data.Contracts.Models;

namespace Prikhodko.BookCatalogue.Config.MappingProfiles
{
    public class BookCatalogueMappingProfile : Profile
    {
        public BookCatalogueMappingProfile()
        {
            MapBookToBookViewModel();
            MapBookViewModelToBook();
            MapLanguageToLanguageViewModel();
            MapLanguageViewModelToLanguage();
        }

        public void MapBookToBookViewModel()
        {
            CreateMap<Book, BookViewModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.BookId))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest => dest.AuthorFirstName, c => c.MapFrom(src => src.Author.FirstName))
                .ForMember(dest => dest.AuthorLastName, c => c.MapFrom(src => src.Author.LastName))
                .ForMember(dest => dest.DateOfIssue, c => c.MapFrom(src => src.DateOfIssue))
                .ForMember(dest => dest.Genre, c => c.MapFrom(src => src.Genre))
                .ForMember(dest => dest.IsPaper, c => c.MapFrom(src => src.IsPaper))
                .ForMember(dest => dest.DeliveryOption, c => c.MapFrom(src => src.DeliveryOption))
                /*.ForMember(dest => dest.AvailableLanguages, c => c.MapFrom(src => src.AvailableLanguages)) ignoring this property because BookViewModel List is <string> and Book List is <Language>*/
                .ForAllOtherMembers(c => c.Ignore());
        }


        public void MapBookViewModelToBook()
        {
            CreateMap<BookViewModel, Book>()
                .ForMember(dest => dest.BookId, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForPath(dest => dest.Author.FirstName, c => c.MapFrom(src => src.AuthorFirstName))
                .ForPath(dest => dest.Author.LastName, c => c.MapFrom(src => src.AuthorLastName))
                .ForMember(dest => dest.DateOfIssue, c => c.MapFrom(src => src.DateOfIssue))
                .ForMember(dest => dest.Genre, c => c.MapFrom(src => src.Genre))
                .ForMember(dest => dest.IsPaper, c => c.MapFrom(src => src.IsPaper))
                .ForMember(dest => dest.DeliveryOption, c => c.MapFrom(src => src.DeliveryOption))
                /*.ForMember(dest => dest.AvailableLanguages, c => c.MapFrom(src => src.AvailableLanguages)) ignoring this property because BookViewModel List is <string> and Book List is <Language>*/
                .ForAllOtherMembers(c => c.Ignore());
        }

        public void MapLanguageToLanguageViewModel()
        {
            CreateMap<Language, LanguageViewModel>()
                .ForMember(dest => dest.LanguageId, c => c.MapFrom((src => src.LanguageId)))
                .ForMember(dest => dest.Name, c => c.MapFrom((src => src.Name)))
                .ForMember(dest => dest.Code, c => c.MapFrom((src => src.Code)))
                .ForAllOtherMembers(c => c.Ignore());
        }

        public void MapLanguageViewModelToLanguage()
        {
            CreateMap<LanguageViewModel, Language>()
                .ForMember(dest => dest.LanguageId, c => c.MapFrom((src => src.LanguageId)))
                .ForMember(dest => dest.Name, c => c.MapFrom((src => src.Name)))
                .ForMember(dest => dest.Code, c => c.MapFrom((src => src.Code)))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}
