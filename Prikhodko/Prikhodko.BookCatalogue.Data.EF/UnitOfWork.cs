using System.Collections.Generic;
using Prikhodko.BookCatalogue.Data.Contracts.Interfaces;
using Prikhodko.BookCatalogue.Data.Contracts.Models;
using System.Linq;
using System.Data.Objects;
using System;

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
            using (var transaction = applicationDbContext.Database.BeginTransaction())
            {
                try
                {
                    applicationDbContext.ChangeTracker.DetectChanges();
                    var entries = applicationDbContext.ChangeTracker.Entries().Where(e => e.State == System.Data.Entity.EntityState.Modified).ToList();
                    //var bookEntries = applicationDbContext.ChangeTracker.Entries().Where(e => e.GetType().IsAssignableFrom(typeof(Book))).ToList();
                    foreach (var entry in entries)
                    {
                        var changedValues = applicationDbContext.GetChangedValues(entry);
                        foreach (var changedValue in changedValues)
                        {
                            BookChange bookChange = new BookChange()
                            {
                                ChangedProperty = changedValue.Key,
                                NewValue = changedValue.Value.ToString(),
                                TimeOfChange = DateTime.Now
                            };
                            applicationDbContext.BookChanges.Add(bookChange);
                        }
                    }
                    applicationDbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    var t = e;
                    transaction.Rollback();
                }
            }
        }
    }
}
