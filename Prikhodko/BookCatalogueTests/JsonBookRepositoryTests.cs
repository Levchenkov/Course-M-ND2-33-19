using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookCatalogue;
using System.IO;

namespace BookCatalogueTests
{
    [TestClass]
    public class JsonBookRepositoryTests
    {
        [TestInitialize]
        public void ClearDatabase()
        {
            File.Delete("books.json");
        }

        [TestMethod]
        public void BooksTest_Unloaded_ShouldLoad()
        {
            // Arrange
            JsonBookRepository jsonBookRepository = new JsonBookRepository();

            // Act
            var books = jsonBookRepository.Books;

            //Assert
            Assert.IsNotNull(books);
        }

        [TestMethod]
        public void AddBookTest_PassValidBook_ShouldAddToCollection()
        {
            // Arrange
            JsonBookRepository jsonBookRepository = new JsonBookRepository();
            Book book = new Book();

            // Act
            jsonBookRepository.Add(book);

            //Assert
            Assert.AreEqual(1, book.Id);
            Assert.AreEqual(1, jsonBookRepository.Books.Count);
        }

        [TestMethod]
        public void AddBookTest_PassInvalidBook_ShouldNotAddToCollection()
        {
            // Arrange
            JsonBookRepository jsonBookRepository = new JsonBookRepository();
            Book book = null;

            // Act
            jsonBookRepository.Add(book);

            //Assert
            Assert.AreEqual(0, jsonBookRepository.Books.Count);
        }

        [TestMethod]
        public void GetBookTest_PassValidId_ShouldReturnBook()
        {
            // Arrange
            JsonBookRepository jsonBookRepository = new JsonBookRepository();
            Book book = new Book();
            jsonBookRepository.Add(book);

            // Act
            var actual = jsonBookRepository.Get(book.Id);


            //Assert
            Assert.AreEqual(actual, book);
        }

        [TestMethod]
        public void GetBookTest_PassInValidId_ShouldNotReturnBook()
        {
            // Arrange
            JsonBookRepository jsonBookRepository = new JsonBookRepository();

            // Act
            var actual = jsonBookRepository.Get(0);


            //Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetBooksTest_ShouldReturnBooks()
        {
            //Arrange
            JsonBookRepository jsonBookRepository = new JsonBookRepository();
            Book book = new Book();
            jsonBookRepository.Add(book);

            //Act
            var books = jsonBookRepository.GetAll();

            //Assert
            Assert.IsNotNull(books);
            Assert.AreEqual(1, books.Count);
        }

        [TestMethod]
        public void RemoveTest_PassValidBook_ShouldRemoveFromCollection()
        {
            // Arrange
            JsonBookRepository jsonBookRepository = new JsonBookRepository();
            Book book = new Book();
            jsonBookRepository.Add(book);

            // Act
            jsonBookRepository.Remove(book.Id);

            //Assert
            Assert.AreEqual(0, jsonBookRepository.Books.Count);
        }

        [TestMethod]
        public void RemoveTest_PassInvalidBook_ShouldNotRemoveFromCollection()
        {
            // Arrange
            JsonBookRepository jsonBookRepository = new JsonBookRepository();
            Book book = new Book();
            jsonBookRepository.Add(book);

            // Act
            jsonBookRepository.Remove(0);

            //Assert
            Assert.AreEqual(1, jsonBookRepository.Books.Count);
        }

        [TestMethod]
        public void UpdateTest_PassValidBook_ShouldRemoveFromCollection()
        {
            // Arrange
            JsonBookRepository jsonBookRepository = new JsonBookRepository();
            Book book = new Book();
            book.Title = "Hello";
            book.Author = "Sasha";
            book.DateOfissue = 1984;
            jsonBookRepository.Add(book);
            int id = book.Id;
            Book book2 = new Book();
            book2.Title = "World";
            book2.Author = "Vasya";
            book2.DateOfissue = 1991;
            book2.Id = id;

            // Act
            jsonBookRepository.Update(book2);

            //Assert
            Assert.AreEqual("World", book.Title);
            Assert.AreEqual("Vasya", book.Author);
            Assert.AreEqual(1991, book.DateOfissue);

        }

        [TestMethod]
        public void UpdateTest_PassInvalidBook_ShouldNotRemoveFromCollection()
        {
            // Arrange
            JsonBookRepository jsonBookRepository = new JsonBookRepository();
            Book book = new Book();
            book.Title = "Hello";
            book.Author = "Sasha";
            book.DateOfissue = 1984;
            jsonBookRepository.Add(book);
            Book book2 = new Book();
            book2.Title = "World";
            book2.Author = "Vasya";
            book2.DateOfissue = 1991;
            book2.Id = 0;

            // Act
            jsonBookRepository.Update(book2);

            //Assert
            Assert.AreEqual("Hello", book.Title);
            Assert.AreEqual("Sasha", book.Author);
            Assert.AreEqual(1984, book.DateOfissue);
        }
    }
}
