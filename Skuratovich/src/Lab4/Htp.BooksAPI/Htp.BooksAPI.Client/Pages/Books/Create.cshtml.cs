using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Htp.BooksAPI.Domain.Contracts.ViewModels;
using Htp.BooksAPI.Domain.Contracts;
using Htp.BooksAPI.Infrastructure;

namespace Htp.BooksAPI.Client.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly IBookService bookService;

        public CreateModel(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookViewModel BookViewModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            BookViewModel.CreatedByUserID = User.GetUserId();

            await bookService.AddAsync(BookViewModel);

            return RedirectToPage("./Index");
        }
    }
}