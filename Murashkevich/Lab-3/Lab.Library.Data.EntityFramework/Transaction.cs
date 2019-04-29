using System.Data.Entity;
using Lab.Library.Data.Contracts;

namespace Lab.Library.Data.EntityFramework
{
    public class Transaction : ITransaction
    {
        private readonly DbContextTransaction _transaction;

        public Transaction(DbContextTransaction transaction)
        {
            _transaction = transaction;
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}
