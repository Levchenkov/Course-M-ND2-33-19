using System;

namespace Http.News.Data.Contracts
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}