using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Htp.BooksAPI.Domain.Contracts.ViewModels;
using Htp.BooksAPI.Domain.Contracts;

namespace Htp.BooksAPI.Client.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly IBookService bookService;

        public DetailsModel(IBookService bookService)
        {
            this.bookService = bookService;
        }

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
    }
}
