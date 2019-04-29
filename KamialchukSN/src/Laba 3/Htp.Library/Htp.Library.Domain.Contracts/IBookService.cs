using Htp.Library.Domain.Contracts.ViewModels;
using System.Collections.Generic;

namespace Htp.Library.Domain.Contracts
{
    public interface IBookService
    {
        BookViewModel Get(int id);
        IEnumerable<BookViewModel> GetAll();

        void Edit(int id, BookViewModel viewModel);
        void Delete(int id);
        void Add(BookViewModel entity);
    }
}
