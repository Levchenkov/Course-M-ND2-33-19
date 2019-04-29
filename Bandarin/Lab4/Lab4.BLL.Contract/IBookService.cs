using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BLL.Contract
{
    public interface IBookService
    {
        BookViewModel Get(int id);
        void Save(BookViewModel viewModel);
        void Add(BookViewModel viewModel);
        void Delete(BookViewModel viewModel);
        void Update(BookViewModel viewModel);
    }
}
