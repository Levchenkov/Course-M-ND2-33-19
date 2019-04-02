using System;
using System.Collections.Generic;
using Lab2.Contracts;
using Lab2.Entities.Models;
using Lab2.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Lab2.Tests
{
    [TestClass]
    public class BookRepositoryTest
    {
        //TODO: Read about TestInitialize
        //[TestInitialize]
        //public RepositoryBaseTest()
        //{
        //}

        [TestMethod]
        public void Ctor_NoParameters_LoadFile()
        {
            // Arrange
            var fileHandlerMock = new Mock<IBookFileHandler>();

            // Act
            var subject = new BookRepository(fileHandlerMock.Object);

            // Assert
            fileHandlerMock.Verify(x => x.Load(), Times.Once);
        }

        [TestMethod]
        public void GetByID_BookExists_ShouldReturn()
        {
            // Arrange
            var fileHandlerMock = new Mock<IBookFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { new Book() { Id = 4 } });

            var subject = new BookRepository(fileHandlerMock.Object);

            // Act
            var result = subject.GetBookById(4);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetByID_BookExists_ExpectedException()
        {
            // Arrange
            var fileHandlerMock = new Mock<IBookFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { new Book() { Id = 4 } });

            // Act
            var subject = new BookRepository(fileHandlerMock.Object);

            // Assert
            var result = subject.GetBookById(5);
        }

        [TestMethod]
        public void Add_AddNotNull_ShouldExist()
        {
            // Arrange
            var fileHandlerMock = new Mock<IBookFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { });

            var subject = new BookRepository(fileHandlerMock.Object);
            var newBook = new Book { Id = 13 };

            // Act
            subject.CreateBook(newBook);
            var result = subject.GetBookById(13);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(13, result.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Add_AddNotNull_ExpectedException()
        {
            // Arrange
            var fileHandlerMock = new Mock<IBookFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { });

            var subject = new BookRepository(fileHandlerMock.Object);

            // Act
            subject.CreateBook(new Book { Id = 1, Title = "Book 1" });

            // Assert
            var result = subject.GetBookById(3);
        }

        [TestMethod]
        public void Update_BookExists_ShouldBeChanged()
        {
            // Arrange
            var fileHandlerMock = new Mock<IBookFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { new Book() { Id = 4, Title = "Book 4" } });
            var subject = new BookRepository(fileHandlerMock.Object);
            var book = new Book() { Id = 4, Title = "New book title 4" };

            // Act
            subject.UpdateBook(book);

            // Assert
            var result = subject.GetBookById(4);
            Assert.IsNotNull(result);
            Assert.AreEqual("New book title 4", result.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Update_BookDoesNotExist_ExpectedException()
        {
            // Arrange
            var fileHandlerMock = new Mock<IBookFileHandler>();
            var book = new Book() { Id = 4, Title = "Book 4" };
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { new Book() { Id = 5, Title = "Book 5" } });
            var subject = new BookRepository(fileHandlerMock.Object);
            book.Title = "New book title 4";

            // Act
            subject.UpdateBook(book);

            // Assert
        }

        [TestMethod]
        public void Delete_BookExists_NoException()
        {
            // Arrange
            var fileHandlerMock = new Mock<IBookFileHandler>();
            var book = new Book() { Id = 4, Title = "Book 4" };
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { book });

            // Act
            var subject = new BookRepository(fileHandlerMock.Object);

            subject.DeleteBook(book);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Delete_BookExists_ExpectedException()
        {
            // Arrange
            var fileHandlerMock = new Mock<IBookFileHandler>();
            var book = new Book() { Id = 4, Title = "Book 4" };
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { book });

            // Act
            var subject = new BookRepository(fileHandlerMock.Object);

            subject.DeleteBook(book);
            subject.GetBookById(book.Id);
            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Delete_BookDoesNotExist_ExpectedException()
        {
            // Arrange
            var fileHandlerMock = new Mock<IBookFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { });

            var subject = new BookRepository(fileHandlerMock.Object);

            // Act
            subject.DeleteBook(new Book() { Id = 13 });
            // Assert
        }

        [TestMethod]
        public void Max_BookId_AreEqual_5()
        {
            // Arrange
            var fileHandlerMock = new Mock<IBookFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> {});

            var subject = new BookRepository(fileHandlerMock.Object);

            subject.Create(new Book() { Id = 1, Title = "Book 1"});
            subject.Create(new Book() { Id = 4, Title = "Book 3" });
            subject.Create(new Book() { Id = 2, Title = "Book 2" });
            subject.Create(new Book() { Id = 5, Title = "Book 5" });
            subject.Create(new Book() { Id = 3, Title = "Book 3" });

            // Act
            var result = subject.Max(x => x.Id);
            // Assert
            Assert.AreEqual(5, result);
        }

        //[TestMethod]
        //public void SaveChanges_BookAdded_ShouldSaveWithBook()
        //{
        //    var fileHandlerMock = new Mock<IBookFileHandler>();
        //    var subject = new BookRepository (fileHandlerMock.Object);

        //    subject.CreateBook(new Book { Id = 4, Title = "New book" });
        //    subject.Save();

        //    fileHandlerMock.Verify(x => x.Save(It.Is<List<Book>>(list => list.Any(y => y.Id == 4))), Times.Once);
        //}

    }
}
