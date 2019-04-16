using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Course.RESTapi.Data.Contracts.Entities;
using Course.RESTapi.Domain.Contracts.ViewModels;
using Profile=AutoMapper.Profile;
namespace Course.RESTapi.Infrastructure.MappingProfiles
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
        CreateMap<Book,BookViewModel>()
            .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
            .ForMember(dest => dest.Created, c => c.MapFrom(src => src.Created))
            .ForMember(dest => dest.CreatedBy, c => c.MapFrom(src => src.CreatedBy))
            .ForMember(dest => dest.Updated, c => c.MapFrom(src => src.Updated))
            .ForMember(dest => dest.UpdatedBy, c => c.MapFrom(src => src.UpdatedBy))
            .ForAllOtherMembers(c => c.Ignore());
        }

        private void MapBookViewModelToBook()
        {
            CreateMap<BookViewModel,Book>()
            .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest => dest.Created, c => c.MapFrom(src => src.Created))
                .ForMember(dest => dest.CreatedBy, c => c.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.Updated, c => c.MapFrom(src => src.Updated))
                .ForMember(dest => dest.UpdatedBy, c => c.MapFrom(src => src.UpdatedBy))
                .ForAllOtherMembers(c => c.Ignore());

        }
    }
}
