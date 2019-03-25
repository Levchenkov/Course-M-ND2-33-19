using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    public class BookRepositoryStub : IRepository<Book>
    {
        public Book Get(int id)
        {
            return new Book {Id = id};
        }
    }

    [TestClass]
    public class BookServiceTest
    {
        [TestMethod]
        public void Get_BookExists_ShouldReturn()
        {
            var bookId = 1;
            //initialization
            var bookRepositoryMock = new Mock<IRepository<Book>>();

            bookRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(new Book { Id = bookId, Title = "qwe" });

            var subject = new BookService(bookRepositoryMock.Object); // mock
            //var subject = new BookService(new BookRepositoryStub()); // stub
            //var subject = new BookService(null); // dummy

            //call
            var result = subject.Get(bookId);

            //verification

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);

            bookRepositoryMock.Verify(x => x.Get(It.IsAny<int>()), Times.Once); //spy
        }
    }
}
