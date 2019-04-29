using System;
using Htp.Books.Data.Contracts;
using Microsoft.EntityFrameworkCore.Storage;

namespace Htp.Books.Data.EntityFramework
{
    public class Transaction : ITransaction
    {
        private readonly IDbContextTransaction transaction;

        public Transaction(IDbContextTransaction transaction)
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