using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Htp.Validation.Data.Contracts;
using Htp.Validation.Data.Contracts.Entities;
using Htp.Validation.Domain.Contracts;
using Htp.Validation.Domain.Contracts.Comands;
using Htp.Validation.Domain.Contracts.Models;

namespace Htp.Validation.Domain.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PaymentModel>> GetAllAsync()
        {
            var payments = await unitOfWork.Repository<Payment>().GetAllAsync();
            var result = mapper.Map<IEnumerable<PaymentModel>>(payments);
            return result;
        }

        public async Task<PaymentModel> GetAsync(int id)
        {
            var payment = await unitOfWork.Repository<Payment>().GetAsync(id);

            var result = mapper.Map<PaymentModel>(payment);
            return result;
        }

        public async Task<PaymentModel> AddAsync(CreatePaymentRequest createPaymentRequest)
        {
            var payment = mapper.Map<Payment>(createPaymentRequest);

            using (var transaction = unitOfWork.BeginTransaction())
            {
                try
                {
                    await unitOfWork.Repository<Payment>().AddAsync(payment);
                    await unitOfWork.SaveChangesAsync();
                    transaction.Commit();

                    var paymentModel = mapper.Map<PaymentModel>(payment);

                    return paymentModel;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
