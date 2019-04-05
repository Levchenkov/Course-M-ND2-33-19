using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course.Library.Data.Contracts;

namespace Course.Library.Data.EntityFramework
{
    class Transaction : ITransaction
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

        public void RollBack()
        {
            transaction.Rollback();
        }

        public void Dispose()
        {
            transaction.Dispose();
        }
    }
}
