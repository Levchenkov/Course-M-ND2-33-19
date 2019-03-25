using System;
using System.Collections.Generic;
using System.Text;
using BookLibrary;
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

        public void Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Change(Book book)
        {
            throw new NotImplementedException();
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
