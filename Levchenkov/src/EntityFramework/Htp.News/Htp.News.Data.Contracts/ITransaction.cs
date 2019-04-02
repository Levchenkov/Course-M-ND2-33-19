using System;

namespace Htp.News.Data.Contracts
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}