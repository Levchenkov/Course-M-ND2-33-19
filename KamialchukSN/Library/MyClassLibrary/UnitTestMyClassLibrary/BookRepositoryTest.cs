using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestMyClassLibrary
{
    [TestClass]
    public class BookRepositoryTest
    {
        [TestMethod]
        public void Ctor_NoParameters_LoadFile()
        {
            // Arrange
            var fileHandlerMock = new Mock<IFileHandler>();
            // Act
            var subject = new BookRepository(fileHandlerMock.Object);
            // Assert
            fileHandlerMock.Verify(x => x.Load(), Times.Once);
        }

        [TestMethod]
        public void Get_BookExists_ShouldReturn()
        {
            // Arrange
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { new Book() { Id = 1, Title = "Book1" } });
            var subject = new BookRepository(fileHandlerMock.Object);
            // Act
            var result = subject.Get(1);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Get_BookDoesNotExists_ExpectedException()
        {
            // Arrange
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { new Book() { Id = 1, Title = "Book1" } });
            var subject = new BookRepository(fileHandlerMock.Object);
            // Act
            var result = subject.Get(5);
        }

        [TestMethod]
        public void Add_AddNotNull_ShouldExist()
        {
            // Arrange
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { });
            var subject = new BookRepository(fileHandlerMock.Object);
            // Act
            subject.Add(new Book { Id = 6, Title = "Book6" });
            var result = subject.Get(6);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(6, result.Id);
        }

        [TestMethod]
        public void Edit_BookExists_ShouldBeChanged()
        {
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { });
            var subject = new BookRepository(fileHandlerMock.Object);
            subject.Add(new Book { Id = 6, Title = "Book6" });
            subject.Edit(new Book { Id = 6, Title = "Book66" });
            var result = subject.Get(6);
            Assert.IsNotNull(result);
            Assert.AreEqual("Book66", result.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Edit_BookDoesNotExist_ExpectedException()
        {
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { });
            var subject = new BookRepository(fileHandlerMock.Object);
            subject.Edit(new Book { Id = 42, Title = "Book42" });
        }

        [TestMethod]
        public void Delete_BookExists_NoException()
        {
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { new Book() { Id = 11, Title = "Book11" } });
            var subject = new BookRepository(fileHandlerMock.Object);
            subject.Delete(11);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Delete_BookDoesNotExist_ExpectedException()
        {
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { });
            var subject = new BookRepository(fileHandlerMock.Object);
            subject.Delete(12);
        }

        [TestMethod]
        public void SaveChanges_BookAdded_ShouldSaveWithBook()
        {
            var fileHandlerMock = new Mock<IFileHandler>();
            var subject = new BookRepository(fileHandlerMock.Object);
            subject.Add(new Book { Id = 2, Title = "Book2" });
            subject.SaveChanges();
            fileHandlerMock.Verify(x => x.Save(It.Is<List<Book>>(list => list.Any(y => y.Id == 2))), Times.Once);
        }
    }
}
