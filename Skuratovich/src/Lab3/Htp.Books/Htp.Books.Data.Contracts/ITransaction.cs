using System;
namespace Htp.Books.Data.Contracts
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}