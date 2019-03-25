using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using BookLibraryCRUD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace UnitTestBookLibrary
{
    [TestClass]
    public class LibraryDBInitializatorTest
    {
        [TestMethod]
        public void LibraryDBInitializatorTest_DataDoesNotExist_ShouldReturnData()
        {
            // Arrange

            // Act
            var db = new LibraryDBInitializator();

            // Assert
            Assert.IsNotNull(db.Books);
        }

        [TestMethod]
        public void SetDbToJsonTest_OutDataFileNotEmpty()
        {
            var jsonFormatter =
                new DataContractJsonSerializer(typeof(List<Book>));
            var path = @"../../../App_Data/library.json";

            File.WriteAllText(path, string.Empty);

            // Arrange
            var db = new LibraryDBInitializator();

            // Act
            db.SaveDbToJson();

            // Assert
            Assert.IsTrue(new FileInfo(path).Length > 0);
        }
    }

    [TestClass]
    public class LibraryRepositoryTest
    {
        private readonly ILibrary repository = new LibraryRepository();

        [TestMethod]
        public void GetParamIdTest_SouldReturn_Id()
        {
            var bookId = 1;
            //initialization
            var bookRepositoryMock = new Mock<ILibrary>();
            bookRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                              .Returns(new Book {Id = bookId, Title = "qwe"});
            var subject = new BookService(bookRepositoryMock.Object); // mock

            //call
            var result = subject.Get(bookId);

            //verification
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);

            bookRepositoryMock.Verify(x => x.Get(It.IsAny<int>()), Times.Once); //spy
        }

        [TestMethod]
        public void GetLastTest_SouldReturnLastBook()
        {
            //initialization
            var Books = repository.GetBooks();
            var bk = Books.Last().Title;

            //call
            var result = repository.GetLast();

            //verification
            Assert.IsNotNull(result);
            Assert.AreEqual(bk, result.Title);
        }

        [TestMethod]
        public void AddTest_SouldReturnTrue()
        {
            // initialization
            var mock = new Mock<ILibrary>();
            mock.Setup(a => a.Add(It.IsAny<Book>())).Verifiable();
            var result = mock.Object;

            // call
            result.Add(new Book());

            // verification
            mock.Verify();
        }

        [TestMethod]
        public void DeleteTest_SouldReturnTrue()
        {
            // initialization
            var mock = new Mock<ILibrary>();
            mock.Setup(x => x.Delete(It.IsAny<int>())).Verifiable();
            var result = mock.Object;

            // call
            result.Delete(2);

            // verification
            mock.Verify();
        }

        [TestMethod]
        public void GetBooksTest_SouldReturnIList()
        {
            //initialization

            //call
            var result = repository.GetBooks();

            //verification
            Assert.IsNotNull(result);
        }
    }


    [TestClass]
    public class BookServiceTest
    {
        [TestMethod]
        public void AddBook_SouldCreate_NewItem()
        {
            var _title = "empty";
            var book1 = new Book {Id = 111, Title = "111"};

            var mockRepository = new Mock<ILibrary>();
            mockRepository.Setup(x => x.Add(book1));
            mockRepository.Setup(x => x.GetLast()).Returns(book1);
            mockRepository.Setup(x => x.Get(It.IsAny<int>()))
                          .Returns(new Book {Id = 112, Title = "new " + _title});

            var subject = new BookService(mockRepository.Object);

            subject.AddBook("new " + _title);
            var res = subject.Get(112);

            Assert.AreEqual("new " + _title, res.Title);
            mockRepository.Verify();
        }

        [TestMethod]
        public void EditBook_Sould_ModifiedItem()
        {
            var _title = "empty";

            var mockRepository = new Mock<ILibrary>();
            mockRepository.Setup(x => x.Edit(It.IsAny<int>()))
                          .Returns(new Book {Id = 111, Title = "mod " + _title});

            var subject = new BookService(mockRepository.Object);

            subject.EditBook(111);

            mockRepository.Verify(x=>x.Edit(111));
        }

        [TestMethod]
        public void DeleteBook_Sould_RemovedItem()
        {
            var mockRepository = new Mock<ILibrary>();
            mockRepository.Setup(x => x.Delete(It.IsAny<int>())).Verifiable();

            var subject = new BookService(mockRepository.Object);

            subject.DeleteBook(111);

            mockRepository.Verify(x => x.Delete(111));
        }

        [TestMethod]
        public void GetLastId_SouldReturn_LastItemId()
        {
            var _title = "empty";
            var book = new Book {Id = 111, Title = _title};

            var mockRepository = new Mock<ILibrary>();
            mockRepository.Setup(x => x.GetLast()).Returns(() => book);

            var subject = new BookService(mockRepository.Object);
            var result = subject.GetLastId();

            Assert.IsNotNull(result);
            Assert.AreEqual(111, result);
        }

        [TestMethod]
        public void Get_withParamId_SouldReturn_ItemId()
        {
            var _title = "empty";
            var book = new Book { Id = 111, Title = _title };

            var mockRepository = new Mock<ILibrary>();
            mockRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(() => book);

            var subject = new BookService(mockRepository.Object);
            var result = subject.Get(111);

            Assert.IsNotNull(result);
            Assert.AreEqual(111, result.Id);
        }

    }
}