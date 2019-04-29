using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Profile = AutoMapper.Profile;
using Lab3.DAL.Contracts.Entities;
using Lab3.BLL.Contracts.ViewModels;
using System.Threading.Tasks;

namespace Lab3.Infrasruct.MappingProfiles
{
    public class BookMappigProfile: Profile 
    {
        
    
        public BookMappigProfile()
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
                .ForMember(dest => dest.IsPaper, c => c.MapFrom(src => src.IsPaper))
                .ForMember(dest => dest.GenreID, c => c.MapFrom(src => src.Genre.Id))
                .ForMember(dest => dest.GenreName, c => c.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.LongVersion, c => c.MapFrom(src => src.LongVersion))
                .ForMember(dest => dest.DeliveryID, c => c.MapFrom(src => src.Delivery.Id))
                .ForMember(dest => dest.DeliveryType, c => c.MapFrom(src => src.Delivery.Type))
                .ForMember(dest => dest.LanguagesID, c => c.MapFrom(src => src.Languagess))
                //.ForMember(dest => dest.GenresAvailable, c => c.MapFrom(src => src.GenresAvailable))
                //.ForMember(dest => dest.LanguageAvailable, c => c.MapFrom(src => src.LanguageAvailable))
                .ForAllOtherMembers(c => c.Ignore());
        }



            private void MapBookViewModelToBook()
            {
                CreateMap<BookViewModel, Book>()
                    .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                    .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Author, c => c.MapFrom(src => src.Author))
                    .ForMember(dest => dest.Created, c => c.MapFrom(src => src.Created))
                    .ForMember(dest => dest.LongVersion, c => c.MapFrom(src => src.LongVersion))
                    
                    .ForPath(dest => dest.Genre.Name, c => c.MapFrom(src => src.GenreName))
                    .ForMember(dest => dest.IsPaper, c => c.MapFrom(src => src.IsPaper))
                    
                    .ForPath(dest => dest.Delivery.Type, c => c.MapFrom(src => src.DeliveryType))
                    .ForPath(dest => dest.Languagess, c => c.MapFrom(src => src.LanguagesID))
                    //.ForMember(dest => dest.GenresAvailable, c => c.MapFrom(src => src.GenresAvailable))
                    //.ForMember(dest => dest.LanguageAvailable, c => c.MapFrom(src => src.LanguageAvailable))
                    .ForAllOtherMembers(c => c.Ignore());
            }


        
        

    }
}
