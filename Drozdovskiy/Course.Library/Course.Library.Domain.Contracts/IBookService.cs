using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course.Library.Domain.Contracts.ViewModels;
using Course.Library.Data.Contracts.Entities;
namespace Course.Library.Domain.Contracts
{
    public interface IBookService
    {
        BookViewModel Get(int id);
        IEnumerable<BookViewModel> GetAll();
        IList<string> GetGenres();
        IList<string> GetLanguages();
        void Save(BookViewModel viewModel);
        void Delete(int id);
    }
}
