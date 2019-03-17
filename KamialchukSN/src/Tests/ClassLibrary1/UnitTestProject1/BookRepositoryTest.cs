using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class BookRepositoryTest
    {
        [TestMethod]
        public void Add_CalledAtLeastOnce_True()
        {
            // Arrange
            var mock = new Mock<BookRepository>();
            mock.Setup(p => p.Add(It.IsAny<Book>())).Verifiable();
            var a = mock.Object;
            // Act
            a.Add(new Book());
            // Assert
            mock.Verify();
        }

        [TestMethod]
        public void Change_CalledAtLeastOnce_True()
        {
            // Arrange
            var mock = new Mock<BookRepository>();
            mock.Setup(p => p.Change(It.IsAny<int>(), It.IsAny<Book>())).Verifiable();
            var a = mock.Object;
            // Act
            a.Change(1, new Book());
            // Assert
            mock.Verify();
        }

        [TestMethod]
        public void Delete_CalledAtLeastOnce_True()
        {
            // Arrange
            var mock = new Mock<BookRepository>();
            mock.Setup(p => p.Delete(It.IsAny<int>())).Verifiable();
            var a = mock.Object;
            // Act
            a.Delete(1);
            // Assert
            mock.Verify();
        }
    }
}
