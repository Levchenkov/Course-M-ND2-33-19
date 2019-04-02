using System.Collections.Generic;
using Htp.Books.Domain.Contracts.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Htp.Books.Domain.Contracts
{
    //TODO: create common interfece for Servicies?
    public interface IBookService
    {
        IEnumerable<HistoryLogViewModel> GetHistoryLogs(int id);

        void Test(BookViewModel bookViewModel);

        IEnumerable<BookViewModel> GetAll();
        BookViewModel Get(int id);
        void Add(BookViewModel bookViewModel);
        void Edit(BookViewModel bookViewModel);
        List<SelectListItem> GetGenres();
    }
}
