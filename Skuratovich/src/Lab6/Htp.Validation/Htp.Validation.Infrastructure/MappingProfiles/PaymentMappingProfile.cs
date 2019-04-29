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
                .ForMember(dest => dest.City, c => c.MapFrom(src => src.City))
                .ForMember(dest => dest.Country, c => c.MapFrom(src => src.Country))
                .ForMember(dest => dest.PostCode, c => c.MapFrom(src => src.PostCode))
                .ForMember(dest => dest.Email, c => c.MapFrom(src => src.Email))
                .ForMember(dest => dest.Amount, c => c.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest => dest.CreditCardNumber, c => c.MapFrom(src => src.CreditCardNumber))
                .ForMember(dest => dest.ExpirationMonth, c => c.MapFrom(src => src.ExpirationMonth))
                .ForMember(dest => dest.ExpirationYear, c => c.MapFrom(src => src.ExpirationYear))
                .ForAllOtherMembers(c => c.Ignore());
        }

        private void MapPaymentRequestToPayment()
        {
            CreateMap<CreatePaymentRequest, Payment>()
                .ForMember(dest => dest.FirstName, c => c.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.MiddleName, c => c.MapFrom(src => src.MiddleName))
                .ForMember(dest => dest.LastName, c => c.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Address, c => c.MapFrom(src => src.Address))
                .ForMember(dest => dest.City, c => c.MapFrom(src => src.City))
                .ForMember(dest => dest.Country, c => c.MapFrom(src => src.Country))
                .ForMember(dest => dest.PostCode, c => c.MapFrom(src => src.PostCode))
                .ForMember(dest => dest.Email, c => c.MapFrom(src => src.Email))
                .ForMember(dest => dest.Amount, c => c.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest => dest.CreditCardNumber, c => c.MapFrom(src => src.CreditCardNumber))
                .ForMember(dest => dest.ExpirationMonth, c => c.MapFrom(src => src.ExpirationMonth))
                .ForMember(dest => dest.ExpirationYear, c => c.MapFrom(src => src.ExpirationYear))
                .ForMember(dest => dest.SecurityCode, c => c.MapFrom(src => src.SecurityCode))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}
