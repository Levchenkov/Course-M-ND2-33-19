using System.Data.Entity;
using Http.BooksLibrary.Data.Contracts;

namespace Http.BooksLibrary.Data.EntityFramework
{
    public class Transaction : ITransaction
    {
        private readonly DbContextTransaction transaction;

        public Transaction(DbContextTransaction transaction)
        {
            this.transaction = transaction;
        }

        public void Dispose()
        {
            transaction.Dispose();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }
    }
}