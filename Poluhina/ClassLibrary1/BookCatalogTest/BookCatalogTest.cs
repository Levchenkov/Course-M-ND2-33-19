using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace BookCatalog.Tests
{
    [TestClass]
    public class BookRepositoryTest
    {
        [TestMethod]
        public void Called_At_Least_Once_True()
        {
            // Arrange
            var mock = new Mock<IJsonFormat>();
            mock.Setup(x => x.Serialize(It.IsAny<List<Book>>()));
            mock.Setup(x => x.Deserialize()).Returns(new List<Book>());
            var repository = new BookRepository(mock.Object);
            // Assert
            mock.Verify();
        }
        [TestMethod]
        public void GetCount_ListBookCount_1()
        {
            // Arrange
            var mock = new Mock<IJsonFormat>();
            mock.Setup(x => x.Deserialize()).Returns(new List<Book>() { new Book { Id = 1, Author = "Name" } });
            var repository = new BookRepository(mock.Object);
            //Act
            var result = repository.GetCount();
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void AddBook_NotNull_True()
        {
            // Arrange
            var mock = new Mock<IJsonFormat>();
            mock.Setup(x => x.Deserialize()).Returns(new List<Book>());
            var repository = new BookRepository(mock.Object);
            //Act
            repository.Add(new Book { Id = 1, Author = "Name" });
            var result = repository.GetCount();
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }
        [TestMethod]

        public void ChangeBook_ShouldBe_True()
        {
            var listBook = new List<Book>() { new Book { Id = 1, Author = "Name" } };
            // Arrange
            var mock = new Mock<IJsonFormat>();
            mock.Setup(x => x.Deserialize()).Returns(listBook);
            var repository = new BookRepository(mock.Object);
            //Act
            repository.Change(1, new Book { Id = 1, Author = "Name_2" });
            // Assert
            Assert.AreEqual("Name_2", listBook[0].Author);
        }

        [TestMethod]
        public void RemoveBook_NoException()
        {
            // Arrange
            var mock = new Mock<IJsonFormat>();
            mock.Setup(x => x.Deserialize()).Returns(new List<Book>() { new Book { Id = 1, Author = "Name" } });
            var repository = new BookRepository(mock.Object);
            //Act
            repository.Remove(1);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void RemoveBook_Exception()
        {
            // Arrange
            var mock = new Mock<IJsonFormat>();
            mock.Setup(x => x.Deserialize()).Returns(new List<Book>() { new Book { Id = 1, Author = "Name" } });
            var repository = new BookRepository(mock.Object);
            //Act
            repository.Remove(7);
        }
    }
}
