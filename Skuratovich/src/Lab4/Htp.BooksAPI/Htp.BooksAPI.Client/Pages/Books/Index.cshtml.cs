using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Htp.BooksAPI.Domain.Contracts.ViewModels;
using Htp.BooksAPI.Domain.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace Htp.BooksAPI.Client.Pages.Books
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IBookService bookService;

        public IndexModel(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public IList<BookViewModel> Books { get;set; }

        public async Task OnGetAsync()
        {
            var result = await bookService.GetAllAsync();
            Books = (List<BookViewModel>)result;
        }
    }
}
