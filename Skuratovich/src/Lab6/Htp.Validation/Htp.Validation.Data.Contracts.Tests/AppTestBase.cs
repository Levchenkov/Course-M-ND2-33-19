using System;
using Htp.Validation.Data.Contracts.Tests.Helpers;
using Htp.Validation.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Htp.Validation.Data.Contracts.Tests
{
    public class AppTestBase : IDisposable
    {
        protected readonly ApplicationDbContext context;

        public AppTestBase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context = new ApplicationDbContext(options);

            context.Database.EnsureCreated();

            // Seed the database with test data.
            Utilities.InitializeDbForTests(context);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
