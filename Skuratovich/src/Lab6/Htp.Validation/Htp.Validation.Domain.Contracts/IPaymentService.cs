using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Htp.Validation.Domain.Contracts.Comands;
using Htp.Validation.Domain.Contracts.Models;

namespace Htp.Validation.Domain.Contracts
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentModel>> GetAllAsync();
        Task<PaymentModel> GetAsync(int id);
        Task<PaymentModel> AddAsync(CreatePaymentRequest createPaymentRequest);
    }
}
