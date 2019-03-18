using System;
using System.Collections.Generic;
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
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { new Book() { Id = 4, Title = "Book 4" } });

            var subject = new BookRepository(fileHandlerMock.Object);

            var result = subject.Get(4);

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Id);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Get_BookExists_ExpectedException()
        {
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { new Book() { Id = 4, Title = "Book 4" } });

            var subject = new BookRepository(fileHandlerMock.Object);

            var result = subject.Get(5);
        }


        [TestMethod]
        public void Add_AddNotNull_ShouldExist()
        {
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { });

            var subject = new BookRepository(fileHandlerMock.Object);

            subject.Add(new Book { Id = 1, Title = "Book 1" });

            var result = subject.Get(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Add_AddNotNull_ExpectedException()
        {
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { });

            var subject = new BookRepository(fileHandlerMock.Object);

            subject.Add(new Book { Id = 1, Title = "Book 1" });

            var result = subject.Get(3);
        }


        [TestMethod]
        public void Edit_BookExists_ShouldBeChanged()
        {
            var fileHandlerMock = new Mock<IFileHandler>();
            var book = new Book() { Id = 4, Title = "Book 4" };
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { book });

            var subject = new BookRepository(fileHandlerMock.Object);

            book.Title = "New book 4";

            Assert.IsTrue(subject.Edit(book));

            var result = subject.Get(4);
            Assert.IsNotNull(result);
            Assert.AreEqual("New book 4", result.Title);
        }


        [TestMethod]
        public void Edit_BookDoesNotExist_ShouldNotBeChanged()
        {
            var fileHandlerMock = new Mock<IFileHandler>();
            var book = new Book() { Id = 4, Title = "Book 4" };
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { new Book() { Id = 5, Title = "Book 5" } });

            var subject = new BookRepository(fileHandlerMock.Object);

            book.Title = "New book 4";

            Assert.IsFalse(subject.Edit(book));

        }


        [TestMethod]
        public void Remove_BookExist_ShouldReturn()
        {
            var fileHandlerMock = new Mock<IFileHandler>();
            var book = new Book() { Id = 4, Title = "Book 4" };
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { book });

            var subject = new BookRepository(fileHandlerMock.Object);

            Assert.IsTrue(subject.Remove(book));
        }


        [TestMethod]
        public void Remove_BookDoseNotExist_ShouldReturn()
        {
            var fileHandlerMock = new Mock<IFileHandler>();
            fileHandlerMock.Setup(x => x.Load()).Returns(new List<Book> { new Book() { Id = 5, Title = "Book 5" } });

            var subject = new BookRepository(fileHandlerMock.Object);

            Assert.IsFalse(subject.Remove(new Book() { Id = 4, Title = "Book 4" }));
        }
    }
}
