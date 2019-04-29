using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prikhodko.BookCatalogue.FrontEnd.Services.Contracts
{
    public interface IFrontEndService<T> where T : class
    {
        Task<bool> Add(T item);
        Task<bool> Update(T item);
        Task<bool> Remove(int id);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
