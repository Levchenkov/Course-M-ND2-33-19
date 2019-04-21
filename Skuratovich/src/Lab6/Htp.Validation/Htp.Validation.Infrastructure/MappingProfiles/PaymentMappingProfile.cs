using AutoMapper;
using Htp.Validation.Data.Contracts.Entities;
using Htp.Validation.Domain.Contracts.Comands;
using Htp.Validation.Domain.Contracts.Models;

namespace Htp.Validation.Infrastructure.MappingProfiles
{
    public class PaymentMappingProfile : Profile
    {
        public PaymentMappingProfile()
        {
            MapPaymentToPaymentModel();
            //MapPaymentModelToPayment();
            MapPaymentRequestToPayment();
        }

        private void MapPaymentToPaymentModel()
        {
            CreateMap<Payment, PaymentModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, c => c.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.MiddleName, c => c.MapFrom(src => src.MiddleName))
                .ForMember(dest => dest.LastName, c => c.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Address, c => c.MapFrom(src => src.Address))
                .ForAllOtherMembers(c => c.Ignore());
        }

        //private void MapPaymentModelToPayment()
        //{
        //    CreateMap<PaymentModel, Payment>()
        //        .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
        //        .ForMember(dest => dest.FirstName, c => c.MapFrom(src => src.FirstName))
        //        .ForMember(dest => dest.MiddleName, c => c.MapFrom(src => src.MiddleName))
        //        .ForMember(dest => dest.LastName, c => c.MapFrom(src => src.LastName))
        //        .ForMember(dest => dest.Address, c => c.MapFrom(src => src.Address))
        //        .ForAllOtherMembers(c => c.Ignore());
        //}

        private void MapPaymentRequestToPayment()
        {
            CreateMap<CreatePaymentRequest, Payment>()
                .ForMember(dest => dest.FirstName, c => c.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.MiddleName, c => c.MapFrom(src => src.MiddleName))
                .ForMember(dest => dest.LastName, c => c.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Address, c => c.MapFrom(src => src.Address))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}
