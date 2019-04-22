using System.Collections.Generic;
using System.Threading.Tasks;
using Htp.Validation.Client.Comands;
using Htp.Validation.Client.Models;

namespace Htp.Validation.Client.Services
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentViewModel>> GetAllAsync();
        Task<PaymentViewModel> AddAsync(CreatePaymentRequest createPaymentRequest);
    }
}
