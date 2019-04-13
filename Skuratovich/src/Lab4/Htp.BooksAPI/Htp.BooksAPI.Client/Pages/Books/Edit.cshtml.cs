using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Htp.BooksAPI.Domain.Contracts.ViewModels;
using Htp.BooksAPI.Domain.Contracts;

namespace Htp.BooksAPI.Client.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly IBookService bookService;

        public EditModel(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [BindProperty]
        public BookViewModel BookViewModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookViewModel = await bookService.GetAsync(id.GetValueOrDefault());

            if (BookViewModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await bookService.EditAsync(BookViewModel);

            return RedirectToPage("./Index");
        }

        //private bool BookViewModelExists(int id)
        //{
        //    return bookService.GetAll().Any(b => b.Id == id);
        //}
    }
}
