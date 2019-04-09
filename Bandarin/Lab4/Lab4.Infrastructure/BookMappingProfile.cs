using AutoMapper;
using Lab4.BLL.Contract;
using Lab4.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Infrastructure
{
    public class BookMappingProfile:Profile
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
                .ForMember(dest => dest.IsCreated, c => c.MapFrom(src => src.IsCreated))
                .ForMember(dest => dest.Updated, c => c.MapFrom(src => src.Updated))
                .ForMember(dest => dest.CreatedUserName, c => c.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.UpdatedUserName, c => c.MapFrom(src => src.UpdatedBy))
                .ForAllOtherMembers(c => c.Ignore());
        }

        private void MapBookViewModelToBook()
        {
            CreateMap<BookViewModel, Book>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsCreated, c => c.MapFrom(src => src.IsCreated))
                .ForMember(dest => dest.Updated, c => c.MapFrom(src => src.Updated))
                .ForMember(dest => dest.CreatedBy, c => c.MapFrom(src => src.CreatedUserName))
                .ForMember(dest => dest.UpdatedBy, c => c.MapFrom(src => src.UpdatedUserName))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}
