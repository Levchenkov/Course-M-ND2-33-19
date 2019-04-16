using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course.RESTapi.Domain.Contracts.ViewModels;

namespace Course.RESTapi.Domain.Contracts
{
    public interface IBookService
    {
        BookViewModel Get(int id);
        void Save(BookViewModel viewModel);
        void Delete(int id);
        IEnumerable<BookViewModel> GetAll();
    }
}
