using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLibraryCRUD;
//using Moq;

namespace UnitTestBookLibrary
{
    [TestClass]
    public class LibraryDBInitializatorTest
    {
        [TestMethod]
        public void LibraryDBInitializatorTest_DataDoesNotExist_ShouldReturnData()
        {
            // Arrange
            LibraryDBInitializator db;

            // Act
            db = new LibraryDBInitializator();

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
            db.SetDbToJson();

            // Assert
            Assert.IsTrue(new FileInfo(path).Length > 0);
        }
    }

    [TestClass]
    public class LibraryRepositoryTest
    {
        private readonly ILibrary repository = new LibraryRepository();

        [TestMethod]
        public void GetParamIdTest_SouldReturnId()
        {
            //initialization
            var Books = repository.GetBooks();
            var enumerable = Books.ToList();
            var _bookTitle = enumerable.First().Title;
            var _bookId = enumerable.First().Id;

            //call
            var result = repository.Get(_bookId);

            //verification
            Assert.IsNotNull(result);
            Assert.AreEqual(_bookTitle, result.Title);
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
            //initialization
            var Books = repository.GetBooks();
            var bk = new Book {Id = 1000, Title = "qwe"};

            //call
            var result = repository.Add(bk);

            //verification
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteTest_SouldReturnTrue()
        {
            //initialization
            var Books = repository.GetBooks();
            var idLast = repository.GetLast().Id;

            //call
            var result = repository.Delete(idLast);

            //verification
            Assert.IsTrue(result);
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

    //[TestClass]
    public class BookServiceTest { }
}