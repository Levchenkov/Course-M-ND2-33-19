using System.Collections.Generic;
using Lab4.Library.Domain.Contracts.ViewModel;

namespace Lab4.Library.Domain.Contracts
{
    public interface IBookService
    {
        BookViewModel Get(int id);
        IEnumerable<BookViewModel> GetAll();
        void Add(BookViewModel entity);
        void Update(BookViewModel entity);
        void Delete(int id);
    }
}
