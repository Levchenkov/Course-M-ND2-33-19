using System;
using AutoMapper;
using Htp.Books.Data.Contracts.Entities;
using Htp.Books.Domain.Contracts.ViewModels;

namespace Htp.Books.Infrastructure.MappingProfiles
{
    public class HistoryLogMappingProfile : Profile
    {
        public HistoryLogMappingProfile()
        {
            MapHistoryLogToHistoryLogViewModel();
            MapHistoryLogViewModelToHistoryLog();
        }

        private void MapHistoryLogToHistoryLogViewModel()
        {
            CreateMap<HistoryLog, HistoryLogViewModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Origin, c => c.MapFrom(src => src.Origin))
                .ForMember(dest => dest.Actually, c => c.MapFrom(src => src.Actually))
                .ForMember(dest => dest.EntityId, c => c.MapFrom(src => src.EntityId))
                .ForMember(dest => dest.EntityType, c => c.MapFrom(src => src.EntityType))
                .ForMember(dest => dest.UpdateTime, c => c.MapFrom(src => src.UpdateTime))
                .ForAllOtherMembers( c => c.Ignore());
        } 

        private void MapHistoryLogViewModelToHistoryLog()
        {
            CreateMap<HistoryLogViewModel, HistoryLog>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Origin, c => c.MapFrom(src => src.Origin))
                .ForMember(dest => dest.Actually, c => c.MapFrom(src => src.Actually))
                .ForMember(dest => dest.EntityId, c => c.MapFrom(src => src.EntityId))
                .ForMember(dest => dest.EntityType, c => c.MapFrom(src => src.EntityType))
                .ForMember(dest => dest.UpdateTime, c => c.MapFrom(src => src.UpdateTime))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}