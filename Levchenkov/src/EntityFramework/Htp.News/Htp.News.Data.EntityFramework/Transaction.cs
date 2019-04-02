using System.Data.Entity;
using Htp.News.Data.Contracts;

namespace Htp.News.Data.EntityFramework
{
    public class Transaction : ITransaction
    {
        private readonly DbContextTransaction transaction;

        public Transaction(DbContextTransaction transaction)
        {
            this.transaction = transaction;
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void Dispose()
        {
            transaction.Dispose();
        }
    }
}