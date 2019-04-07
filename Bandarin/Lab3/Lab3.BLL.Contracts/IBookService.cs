using Lab3.BLL.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.BLL.Contracts
{
    public interface IBookService
    {
        BookViewModel Get(int id);
        void Save(BookViewModel viewModel);
        void Add(BookViewModel viewModel);
        void Remove(BookViewModel viewmodel);

    }
}
