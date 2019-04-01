using System.Collections.Generic;
using Prikhodko.BookCatalogue.Data.Contracts.Interfaces;
using Prikhodko.BookCatalogue.Data.Contracts.Models;

namespace Prikhodko.BookCatalogue.Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        //TODO: Add transaction mechanism

        private readonly ApplicationDbContext applicationDbContext;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        
        public void SaveChanges()
        {
            applicationDbContext.SaveChanges();
        }
    }
}
