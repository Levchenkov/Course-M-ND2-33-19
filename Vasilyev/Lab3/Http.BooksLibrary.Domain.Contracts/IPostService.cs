using System.Collections;
using System.Collections.Generic;
using Http.BooksLibrary.Domain.Contracts.ViewModels;

namespace Http.BooksLibrary.Domain.Contracts
{
    public interface IPostService
    {
        BookViewModel Get(int id);
        IList<BookViewModel> GetAll();
        void Add(BookViewModel viewModel);
        void Save(BookViewModel viewModel);
        void Delete(int id);
    }
}