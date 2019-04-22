using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Htp.Validation.Client.Comands;
using Htp.Validation.Client.Models;
using Htp.Validation.Client.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Htp.Validation.Client.Pages.Payments
{
    public class CreateModel : PageModel
    {
        private readonly IPaymentService paymentService;

        public CreateModel(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreatePaymentRequest CreatePaymentRequest { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await paymentService.AddAsync(CreatePaymentRequest);

            return RedirectToPage("./Index");
        }
    }
}
