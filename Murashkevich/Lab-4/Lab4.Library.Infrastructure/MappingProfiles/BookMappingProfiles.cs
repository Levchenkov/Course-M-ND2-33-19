using Lab4.Library.Data.Contracts.Entities;
using Lab4.Library.Domain.Contracts.ViewModel;
using Profile = AutoMapper.Profile;

namespace Lab4.Library.Infrastructure.MappingProfiles
{
    public class BookMappingProfiles : Profile
    {
        public BookMappingProfiles()
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
                .ForMember(dest => dest.CreatedBy, c => c.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.Create, c => c.MapFrom(src => src.Create))
                .ForMember(dest => dest.UpdatedBy, c => c.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.Updated, c => c.MapFrom(src => src.Updated));
        }

        private void MapBookViewModelToBook()
        {
            CreateMap<Book, BookViewModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest => dest.CreatedBy, c => c.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.Create, c => c.MapFrom(src => src.Create))
                .ForMember(dest => dest.UpdatedBy, c => c.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.Updated, c => c.MapFrom(src => src.Updated));
        }
    }
}
