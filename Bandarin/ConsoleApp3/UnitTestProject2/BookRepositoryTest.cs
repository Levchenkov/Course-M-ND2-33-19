using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using ConsoleApp4;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class BookRepositoryTest
    {
        
        //void Edit(T book);
        //void Remove(int id);
        

        [TestMethod]
        public void Get_BookExists_ShouldReturn()
        {
            var fileMock = new Mock<IFileWorker>();
            fileMock.Setup(x => x.ReadFromJsonFile<List<Book>>("output1.json")).Returns(new List<Book> { new Book(8,"title8") });

            var subject = new BookRepository(fileMock.Object);

            var result = subject.Get(8);

            Assert.IsNotNull(result);
            Assert.AreEqual(8, result.ID);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Get_BookDoesNotExists_ExpectedException()
        {
            var fileMock = new Mock<IFileWorker>();
            fileMock.Setup(x => x.ReadFromJsonFile<List<Book>>("output1.json")).Returns(new List<Book> { new Book(8, "title8") });

            var subject = new BookRepository(fileMock.Object);

            var result = subject.Get(100);
        }

        [TestMethod]
        public void Add_AddNotNull_ShouldExist()
        {
            var fileMock = new Mock<IFileWorker>();
            fileMock.Setup(x => x.ReadFromJsonFile<List<Book>>("output1.json")).Returns(new List<Book> ());

            var subject = new BookRepository(fileMock.Object);

            subject.Add(new Book(17,"title17"));

            var result = subject.Get(17);
            Assert.IsNotNull(result);
            Assert.AreEqual(17, result.ID);
        }

        [TestMethod]
        public void Edit_BookExists_ShouldBeChanged()
        {
            var fileMock = new Mock<IFileWorker>();
            fileMock.Setup(x => x.ReadFromJsonFile<List<Book>>("output1.json")).Returns(new List<Book> { new Book(8, "title8") });

            var subject = new BookRepository(fileMock.Object);

           
            subject.Edit(new Book(8,"changedtitle"));

            var result = subject.Get(8);
            Assert.IsNotNull(result);
            Assert.AreEqual("changedtitle", result.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Edit_BookDoesNotExist_ExpectedException()
        {
            var fileMock = new Mock<IFileWorker>();
            fileMock.Setup(x => x.ReadFromJsonFile<List<Book>>("output1.json")).Returns(new List<Book> { new Book(8, "title8") });

            var subject = new BookRepository(fileMock.Object);

            subject.Edit(new Book(14, "changedtitle"));
        }

        [TestMethod]
        public void Delete_BookExists_NoException()
        {
            var fileMock = new Mock<IFileWorker>();
            fileMock.Setup(x => x.ReadFromJsonFile<List<Book>>("output1.json")).Returns(new List<Book> { new Book(8, "title8") });

            var subject = new BookRepository(fileMock.Object);
            subject.Remove(8);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Delete_BookDoesNotExist_ExpectedException()
        {
            var fileMock = new Mock<IFileWorker>();
            fileMock.Setup(x => x.ReadFromJsonFile<List<Book>>("output1.json")).Returns(new List<Book> { new Book(8, "title8") });

            var subject = new BookRepository(fileMock.Object);
            subject.Remove(16);
        }

        

    }
}
