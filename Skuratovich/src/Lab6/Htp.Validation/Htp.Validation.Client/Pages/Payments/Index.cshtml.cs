using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Htp.Validation.Client.Models;
using Htp.Validation.Client.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Htp.Validation.Client.Pages.Payments
{
    public class IndexModel : PageModel
    {
        private readonly IPaymentService paymentService;

        public IndexModel(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        public IList<PaymentViewModel> Payments { get; set; }

        public async Task OnGetAsync()
        {
            var result = await paymentService.GetAllAsync();
            Payments = (List<PaymentViewModel>)result;
        }
    }
}
