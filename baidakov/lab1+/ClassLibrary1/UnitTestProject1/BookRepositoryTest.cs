using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class BookRepositoryTest
    {
        [TestMethod]
        public void Ctor_NoParameters_LoadFile()
        {
            var fileHandlerMock = new Mock<IFileHandler>();
            var subject = new BookRepository(fileHandlerMock.Object);

            fileHandlerMock.Verify(x => x.Load(), Times.Once);
        }

        [TestMethod]
        public void Get_BookExists_ShouldReturn()
        {
            // Arrange
            var fileHandlerMock = new Mock<IRepository<Book>>();
            fileHandlerMock.Setup(x => x.Get(It.IsAny<int>())).Returns(new Book { Id = 100, Title = "Title100" });
            var subject = fileHandlerMock.Object;
            // Act
            Book result = subject.Get(100);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(100, result.Id);
            fileHandlerMock.Verify(x => x.Get(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Get_BookDoesNotExists_ExpectedException()
        {
            // Arrange
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { new Book() { Id = 10, Title = "Title10" } });
            var subject = new BookRepository(fileHandlerMock.Object);
            //Act
            var result = subject.Get(100);
            //Assert
            Assert.AreNotEqual(100, result.Id);
        }

        [TestMethod]
        public void Add_AddNotNull_ShouldExist()
        {
            // Arrange
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> {  });
            var subject = new BookRepository(fileHandlerMock.Object);
            //Act
            subject.Add(new Book {Id = 12, Title = "Title10"});
            var result = subject.Get(12);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(12, result.Id);
        }

        [TestMethod]
        public void Edit_BookExists_ShouldBeChanged()
        {
            //Arrange
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { });
            //Act
            var subject = new BookRepository(fileHandlerMock.Object);
            subject.Add(new Book { Id = 15, Title = "Title" });
            subject.Edit(15, new Book { Id = 15, Title = "newTitle" });
           var result = subject.Get(15);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual("Title15", result.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Edit_BookDoesNotExist_ExpectedException()
        {
            //Arrange
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { });
            //Act
            var subject = new BookRepository(fileHandlerMock.Object);
            subject.Edit(12, new Book { Id = 12, Title = "newTitle" });
        }

        [TestMethod]
        public void Delete_BookExists_NoException()
        {
            //Arrange
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { new Book() { Id = 10, Title = "10" } });
            //Act
            var subject = new BookRepository(fileHandlerMock.Object);
            subject.Delete(10);


        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Delete_BookDoesNotExist_ExpectedException()
        {
            //Arrange
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { });
            //Act
            var subject = new BookRepository(fileHandlerMock.Object);
            subject.Delete(10);
        }

        [TestMethod]
        public void SaveChanges_BookAdded_ShouldSaveWithBook()
        {
            //Arrange
            var fileHandlerMock = new Mock<IFileHandler>();
            //Act
            var subject = new BookRepository(fileHandlerMock.Object);
            subject.Add(new Book {Id = 42, Title = "42"});
            subject.SaveChanges();

            fileHandlerMock.Verify(x => x.Save(It.Is<List<Book>>(list => list.Any(y => y.Id == 42))), Times.Once);
        }

        
    }
}
