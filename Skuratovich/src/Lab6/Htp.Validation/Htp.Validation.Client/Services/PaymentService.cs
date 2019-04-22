using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Htp.Validation.Client.Comands;
using Htp.Validation.Client.DTOs;
using Htp.Validation.Client.Models;
using Newtonsoft.Json;

namespace Htp.Validation.Client.Services
{
    public class PaymentService : IPaymentService
    {
        private const string baseUri = "http://localhost:5001/api/payments";

        private readonly IMapper mapper;

        public PaymentService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<PaymentViewModel> AddAsync(CreatePaymentRequest createPaymentRequest)
        {
            var httpClient = new HttpClient();

            var payment = mapper.Map<PaymentDto>(createPaymentRequest);

            var jsonString = JsonConvert.SerializeObject(createPaymentRequest);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{baseUri}", content);

            response.EnsureSuccessStatusCode();
            jsonString = await response.Content.ReadAsStringAsync();

            payment = JsonConvert.DeserializeObject<PaymentDto>(jsonString);

            var result = mapper.Map<PaymentViewModel>(payment);

            return result;
        }

        public async Task<IEnumerable<PaymentViewModel>> GetAllAsync()
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync($"{baseUri}");

            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();

            var wrapper = JsonConvert.DeserializeObject<LinkedCollectionResourceWrapper<PaymentDto>>(jsonString);

            var payments = wrapper.Value;

            var result = mapper.Map<IEnumerable<PaymentViewModel>>(payments);

            return result;
        }
    }
}
