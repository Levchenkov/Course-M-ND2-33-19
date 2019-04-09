using System;
namespace Htp.BooksAPI.Data.Contracts
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
