using System;
using System.Collections.Generic;
using System.Linq;
using Lab2.DAL.Entities;
using Lab2.DAL.Interfaces;
using Lab2.DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Lab2.Tests
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
        public void GetByID_BookExists_ShouldReturn()
        {
            // Arrange
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { new Book() { Id = 4, Title = "Book 4" } });

            var subject = new BookRepository(fileHandlerMock.Object);

            // Act
            var result = subject.GetByID(4);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetByID_BookExists_ExpectedException()
        {
            // Arrange
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { new Book() { Id = 4, Title = "Book 4" } });

            // Act
            var subject = new BookRepository(fileHandlerMock.Object);

            // Assert
            var result = subject.GetByID(5);
        }

        [TestMethod]
        public void Add_AddNotNull_ShouldExist()
        {
            // Arrange
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { });

            var subject = new BookRepository(fileHandlerMock.Object);
            var newBook = new Book { Id = 1, Title = "Book 1" };

            // Act
            subject.Add(newBook);
            var result = subject.GetAll();

            // Assert
            CollectionAssert.Contains(result, newBook);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Add_AddNotNull_ExpectedException()
        {
            // Arrange
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { });

            var subject = new BookRepository(fileHandlerMock.Object);

            // Act
            subject.Add(new Book { Id = 1, Title = "Book 1" });

            // Assert
            var result = subject.GetByID(3);
        }

        [TestMethod]
        public void Edit_BookExists_ShouldBeChanged()
        {
            // Arrange
            var fileHandlerMock = new Mock<IFileHandler>();
            var book = new Book() { Id = 4, Title = "Book 4" };
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { book });
            var subject = new BookRepository(fileHandlerMock.Object);
            book.Title = "New book title 4";


            // Act
            subject.Edit(book);

            // Assert
            var result = subject.GetByID(4);
            Assert.IsNotNull(result);
            Assert.AreEqual("New book title 4", result.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Edit_BookDoesNotExist_ExpectedException()
        {
            // Arrange
            var fileHandlerMock = new Mock<IFileHandler>();
            var book = new Book() { Id = 4, Title = "Book 4" };
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { new Book() { Id = 5, Title = "Book 5" } });
            var subject = new BookRepository(fileHandlerMock.Object);
            book.Title = "New book title 4";

            // Act
            subject.Edit(book);

            // Assert
        }

        [TestMethod]
        public void Delete_BookExists_NoException()
        {
            // Arrange
            var fileHandlerMock = new Mock<IFileHandler>();
            var book = new Book() { Id = 4, Title = "Book 4" };
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { book });

            // Act
            var subject = new BookRepository(fileHandlerMock.Object);

            subject.Delete(book.Id);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Delete_BookExists_ExpectedException()
        {
            // Arrange
            var fileHandlerMock = new Mock<IFileHandler>();
            var book = new Book() { Id = 4, Title = "Book 4" };
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { book });

            // Act
            var subject = new BookRepository(fileHandlerMock.Object);

            subject.Delete(book.Id);
            subject.GetByID(book.Id);
            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Delete_BookDoesNotExist_ExpectedException()
        {
            // Arrange
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { });

            var subject = new BookRepository(fileHandlerMock.Object);

            // Act
            subject.Delete(10);
            // Assert
        }

        //[TestMethod]
        //public void SaveChanges_BookAdded_ShouldSaveWithBook()
        //{
        //    var fileHandlerMock = new Mock<IFileHandler>();
        //    var subject = new BookRepository(fileHandlerMock.Object);

        //    subject.Add(new Book { Id = 4, Title = "New book" });
        //    subject.SaveChanges();

        //    fileHandlerMock.Verify(x => x.Save(It.Is<List<Book>>(list => list.Any(y => y.Id == 4))), Times.Once);
        //}
    }
}
