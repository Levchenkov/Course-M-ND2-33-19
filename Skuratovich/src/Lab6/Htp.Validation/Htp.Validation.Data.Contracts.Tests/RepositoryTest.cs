using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Htp.Validation.Data.Contracts.Entities;
using Htp.Validation.Data.Contracts.Tests.Async;
using Htp.Validation.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Htp.Validation.Data.Contracts.Tests
{
    //public class TestClass
    //{
    //    public int Id { get; set; }
    //}

    [TestClass]
    public class RepositoryTest
    {
        // https://stackoverflow.com/questions/40476233/how-to-mock-an-async-repository-with-entity-framework-core
        // https://github.com/aspnet/EntityFramework.Docs/blob/70c71610538a815283d521ae63c33a693229c22f/entity-framework/ef6/fundamentals/testing/mocking.md

        //[TestMethod]
        //public async Task AddAsync_Save_ShouldReturn()
        //{
        //    // Arrange
        //    var mockSet = new Mock<DbSet<Payment>>();

        //    var mockContext = new Mock<ApplicationDbContext>();
        //    mockContext.Setup(m => m.Payments).Returns(mockSet.Object);

        //    var repository = new Repository<Payment>(mockContext.Object);

        //    var payment = new Payment()
        //    {
        //        Id = 1,
        //        FirstName = "1 - First name",
        //        MiddleName = "Middle name",
        //        LastName = "Last name",
        //        Address = "Address",
        //        City = "City",
        //        Country = "Country",
        //        PostCode = "12345",
        //        Email = "a@a.by",
        //        Amount = 123,
        //        Description = "Description",
        //        CreditCardNumber = "4111111111111111",
        //        ExpirationMonth = "01",
        //        ExpirationYear = "20",
        //        SecurityCode = "123"
        //    };

        //    // Act
        //    var result = await repository.AddAsync(payment);

        //    // Assert
        //    mockSet.Verify(m => m.Add(It.IsAny<Payment>()), Times.Once());
        //    //mockContext.Verify(m => m.SaveChangesAsync().Result, Times.Once());
        //}


        [TestMethod]
        public async Task GetAllPaymnets_orders_by_firstName()
        {
            // Arrange
            var data = new List<Payment>
            {
                new Payment { FirstName = "BBB" },
                new Payment { FirstName = "ZZZ" },
                new Payment { FirstName = "AAA" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Payment>>();
            mockSet.As<IAsyncEnumerable<Payment>>()
                .Setup(m => m.GetEnumerator())
                .Returns(new TestAsyncEnumerator<Payment>(data.GetEnumerator()));

            mockSet.As<IQueryable<Payment>>()
                .Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<Payment>(data.Provider));


            //mockSet.As<IQueryable<Payment>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Payment>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Payment>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Payment>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(m => m.Payments).Returns(mockSet.Object);

            var repository = new Repository<Payment>(mockContext.Object);

            // Act
            var payments = await repository.GetAllAsync();

            //Assert
            Assert.AreEqual(3, payments.Count());
            Assert.AreEqual("AAA", payments.ElementAt(0).FirstName);
            Assert.AreEqual("BBB", payments.ElementAt(1).FirstName);
            Assert.AreEqual("ZZZ", payments.ElementAt(2).FirstName);
        }

    }
}
