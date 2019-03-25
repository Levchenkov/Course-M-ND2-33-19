using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BookLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class BookRepositoryTest
    {
        private string path = Directory.GetCurrentDirectory() + @"\books.json";

        [TestMethod]
        public void Ctor_NoParameters_LoadFile()
        {
            var fileHandlerMock = new Mock<IJsonWorker>();

            var subject = new BookRepository(fileHandlerMock.Object);

            fileHandlerMock.Verify(x => x.Load(path), Times.Once);
        }

        [TestMethod]
        public void Get_BookExists_ShouldReturn()
        {
            var fileHandlerMock = new Mock<IJsonWorker>();
            fileHandlerMock.Setup(x => x.Load(path)).Returns(new List<Book> {new Book() {Id = 12, Title = "12"}});
            
            var subject = new BookRepository(fileHandlerMock.Object);

            var result = subject.Get(12);

            Assert.IsNotNull(result);
            Assert.AreEqual(12, result.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Get_BookDoesNotExists_ExpectedException()
        {
            var fileHandlerMock = new Mock<IJsonWorker>();
            fileHandlerMock.Setup(x => x.Load(path)).Returns(new List<Book> { new Book() { Id = 12, Title = "12" } });

            var subject = new BookRepository(fileHandlerMock.Object);

            var result = subject.Get(120);
        }

        [TestMethod]
        public void Add_AddNotNull_ShouldExist()
        {
            var fileHandlerMock = new Mock<IJsonWorker>();
            fileHandlerMock.Setup(x => x.Load(path)).Returns(new List<Book> {  });

            var subject = new BookRepository(fileHandlerMock.Object);

            subject.Add(new Book {Id = 11, Title = "11"});

            var result = subject.Get(11);
            Assert.IsNotNull(result);
            Assert.AreEqual(11, result.Id);
        }

        [TestMethod]
        public void Edit_BookExists_ShouldBeChanged()
        {
            var fileHandlerMock = new Mock<IJsonWorker>();
            fileHandlerMock.Setup(x => x.Load(path)).Returns(new List<Book> { });

            var subject = new BookRepository(fileHandlerMock.Object);

            subject.Add(new Book { Id = 11, Title = "11" });

            subject.Change(new Book { Id = 11, Title = "new 11"});

            var result = subject.Get(11);
            Assert.IsNotNull(result);
            Assert.AreEqual("new 11", result.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Edit_BookDoesNotExist_ExpectedException()
        {
            var fileHandlerMock = new Mock<IJsonWorker>();
            fileHandlerMock.Setup(x => x.Load(path)).Returns(new List<Book> { });

            var subject = new BookRepository(fileHandlerMock.Object);

            subject.Change(new Book { Id = 11, Title = "new 11" });
        }

        [TestMethod]
        public void Delete_BookExists_NoException()
        {
            var fileHandlerMock = new Mock<IJsonWorker>();
            fileHandlerMock.Setup(x => x.Load(path)).Returns(new List<Book> { new Book() { Id = 12, Title = "12" } });

            var subject = new BookRepository(fileHandlerMock.Object);
            subject.Delete(12);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Delete_BookDoesNotExist_ExpectedException()
        {
            var fileHandlerMock = new Mock<IJsonWorker>();
            fileHandlerMock.Setup(x => x.Load(path)).Returns(new List<Book> { });

            var subject = new BookRepository(fileHandlerMock.Object);
            subject.Delete(12);
        }

        [TestMethod]
        public void SaveChanges_BookAdded_ShouldSaveWithBook()
        {
            var fileHandlerMock = new Mock<IJsonWorker>();
            var subject = new BookRepository(fileHandlerMock.Object);
            subject.Add(new Book {Id = 11, Title = "11"});
            subject.SaveChanges();

            fileHandlerMock.Verify(x => x.Save(path, It.Is<List<Book>>(list => list.Any(y => y.Id == 11))), Times.Once);
        }

        
    }
}
