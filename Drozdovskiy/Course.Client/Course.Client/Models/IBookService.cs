using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.FrontendPart.Models
{
    public interface IBookService
    {
        BookViewModel Get(int id);
        IEnumerable<BookViewModel> GetAll();
        void Delete(int id);
        void Post(BookViewModel viewModel);
        void Put(BookViewModel viewModel,int id);
    }
}
