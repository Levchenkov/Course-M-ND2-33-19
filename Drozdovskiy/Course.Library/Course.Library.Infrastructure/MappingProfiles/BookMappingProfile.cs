using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Course.Library.Data.Contracts.Entities;
using Course.Library.Domain.Contracts.ViewModels;
using Profile = AutoMapper.Profile;

namespace Course.Library.Infrastructure.MappingProfiles
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
                .ForMember(dest => dest.Genre, c => c.MapFrom(src => src.Genre.Title))
                .ForMember(dest => dest.Created, c => c.MapFrom(src => src.Created))
                .ForMember(dest => dest.Languages, c => c.MapFrom(src => src.Languages))
                .ForMember(dest => dest.DeliveryRequired, c => c.MapFrom(src => src.DeliveryRequired))
                .ForMember(dest => dest.IsPaper, c => c.MapFrom(src => src.IsPaper))
                .ForMember(dest => dest.AuthorId, c => c.MapFrom(src => src.Author.Id))
                .ForMember(dest => dest.AuthorFirstName, c => c.MapFrom(src => src.Author.Profile.FirstName))
                .ForMember(dest => dest.AuthorLastName, c => c.MapFrom(src => src.Author.Profile.LastName))
                .ForAllOtherMembers(c => c.Ignore());
        }

        private void MapBookViewModelToBook()
        {
            CreateMap<BookViewModel, Book>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest => dest.Genre, c => c.MapFrom(src => new Genre {Title = src.Title}))
                .ForMember(dest => dest.Created, c => c.MapFrom(src => src.Created))
                .ForMember(dest => dest.Languages, c => c.MapFrom(src => src.Languages))
                .ForMember(dest => dest.DeliveryRequired, c => c.MapFrom(src => src.DeliveryRequired))
                .ForMember(dest => dest.IsPaper, c => c.MapFrom(src => src.IsPaper))
                .ForMember(dest => dest.Author, c => c.MapFrom(src => src));
            CreateMap<BookViewModel, Author>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Profile, c => c.MapFrom(src => src));
            CreateMap<BookViewModel, Data.Contracts.Entities.Profile>()
                .ForMember(dest => dest.FirstName, c => c.MapFrom(src => src.AuthorFirstName))
                .ForMember(dest => dest.LastName, c => c.MapFrom(src => src.AuthorLastName))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}
