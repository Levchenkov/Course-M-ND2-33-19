using System.Threading.Tasks;
using Htp.Validation.Data.Contracts.Entities;
using Htp.Validation.Data.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Htp.Validation.Data.Contracts.Tests
{
    [TestClass]
    public class InMemoryRepositoryTest : AppTestBase
    {
        // https://www.youtube.com/watch?v=ddrR440JtiA

        [TestMethod]
        public async Task GetByID_PaymentExists_ShouldReturn()
        {
            // Arrange
            var repository = new Repository<Payment>(context);

            // Act
            var result = await repository.GetAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }

        //[TestMethod]
        //[ExpectedException(typeof(Exception))]
        //public void GetByID_PaymnetExists_ExpectedException()
        //{
        //    // Arrange
          
        //    // Act
          
        //    // Assert
        //}
    }
}
