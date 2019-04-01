using System;
using AutoMapper;
using Htp.Books.Data.Contracts.Entities;
using Htp.Books.Domain.Contracts.ViewModels;

namespace Htp.Books.Infrastructure.MappingProfiles
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
                .ForMember(dest => dest.Author, c => c.MapFrom(src => src.Author))
                .ForMember(dest => dest.Created, c => c.MapFrom(src => src.Created))
                .ForMember(dest => dest.GenreId, c => c.MapFrom(src => src.GenreId))
                .ForMember(dest => dest.IsPaper, c => c.MapFrom(src => src.IsPaper))
                .ForMember(dest => dest.DeliveryRequired, c => c.MapFrom(src => src.DeliveryRequired))
                .ForMember(dest => dest.RowVersion, c => c.MapFrom(src => src.RowVersion))
                .ForAllOtherMembers( c => c.Ignore());
        }

        private void MapBookViewModelToBook()
        {
            CreateMap<BookViewModel, Book>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest => dest.Author, c => c.MapFrom(src => src.Author))
                .ForMember(dest => dest.Created, c => c.MapFrom(src => src.Created))
                .ForPath(dest => dest.GenreId, c => c.MapFrom(src => src.GenreId))
                .ForMember(dest => dest.IsPaper, c => c.MapFrom(src => src.IsPaper))
                .ForMember(dest => dest.DeliveryRequired, c => c.MapFrom(src => src.DeliveryRequired))
                .ForMember(dest => dest.RowVersion, c => c.MapFrom(src => src.RowVersion))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}