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
        }

        public void MapBookToBookViewModel()
        {
            CreateMap<Book, BookViewModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest => dest.Author, c => c.MapFrom(src => src.Author))
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
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest => dest.Author, c => c.MapFrom(src => src.Author))
                .ForMember(dest => dest.DateOfIssue, c => c.MapFrom(src => src.DateOfIssue))
                .ForMember(dest => dest.Genre, c => c.MapFrom(src => src.Genre))
                .ForMember(dest => dest.IsPaper, c => c.MapFrom(src => src.IsPaper))
                .ForMember(dest => dest.DeliveryOption, c => c.MapFrom(src => src.DeliveryOption))
                /*.ForMember(dest => dest.AvailableLanguages, c => c.MapFrom(src => src.AvailableLanguages)) ignoring this property because BookViewModel List is <string> and Book List is <Language>*/
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}
