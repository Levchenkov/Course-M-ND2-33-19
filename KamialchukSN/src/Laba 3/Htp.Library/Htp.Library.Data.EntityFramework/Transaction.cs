using Htp.Library.Data.Contracts;
using System.Data.Entity;

namespace Htp.Library.Data.EntityFramework
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