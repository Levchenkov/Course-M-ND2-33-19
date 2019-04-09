using System.Collections.Generic;
using System.Threading.Tasks;
using Htp.BooksAPI.Domain.Contracts.ViewModels;

namespace Htp.BooksAPI.Domain.Contracts
{
    public interface IBookService
    {
        IEnumerable<BookViewModel> GetAll();
        Task<BookViewModel> GetAsync(int id);
        void Add(BookViewModel bookViewModel);
        Task<bool> EditAsync(BookViewModel bookViewModel);
        void DeleteAsync(int id);
    }
}
