using BookEditing.DAL.Entities;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEditing.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDataRepository<Book> Books { get; }
        void Save();
    }
}
