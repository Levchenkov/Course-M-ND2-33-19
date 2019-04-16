using System.Collections.Generic;
using Lab.Library.Domain.Contracts.ViewModels;

namespace Lab.Library.Domain.Contracts
{
    public interface IBookService
    {
        BookViewModel Get(int id);
        void Add(BookViewModel viewModel);
        IEnumerable<BookViewModel> GetAll();
        void Remove(int id);
        void Update(BookViewModel viewModel);
    }
}
