using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using BookCatalogue;


namespace BookCatalogueTests
{
    [TestClass]
    public class BookServiceTests
    {
        [TestMethod]
        public void AddBookTest_PassValidBook_ShouldAddBookToRepository()
        {
            // Arrange
            var repositoryMock = new Mock<IBookRepository>();
            BookService bookService = new BookService(repositoryMock.Object);
            var bookMock = new Mock<Book>();

            // Act
            bookService.AddBook(bookMock.Object);

            //Assert
            repositoryMock.Verify(x => x.Add(bookMock.Object), Times.Once);
        }

        [TestMethod]
        public void AddBookTest_PassNull_ShouldNotAddBookToRepository()
        {
            // Arrange
            var repositoryMock = new Mock<IBookRepository>();
            BookService bookService = new BookService(repositoryMock.Object);

            // Act
            bookService.AddBook(null);

            //Assert
            repositoryMock.Verify(x => x.Add(It.IsAny<Book>()), Times.Never);
        }

        [TestMethod]
        public void GetBookTest_PassValidId_ShouldCallForRepositoryGetBook()
        {
            //Arrange
            var repositoryMock = new Mock<IBookRepository>();
            BookService bookService = new BookService(repositoryMock.Object);
            int id = 1;

            //Act
            bookService.GetBook(id);

            //Assert
            repositoryMock.Verify(x => x.GetBook(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetBookTest_PassInvalidId_ShouldReturnNull()
        {
            //Arrange
            var repositoryMock = new Mock<IBookRepository>();
            BookService bookService = new BookService(repositoryMock.Object);
            int id = 0;

            //Act
            Book actual = bookService.GetBook(id);

            //Assert
            repositoryMock.Verify(x => x.GetBook(It.IsAny<int>()), Times.Never);
            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void GetBooksTest_ShouldCallRepositoryGetBooksMethod()
        {
            //Arrange
            var repositoryMock = new Mock<IBookRepository>();
            BookService bookService = new BookService(repositoryMock.Object);

            //Act
            IEnumerable<Book> actual = bookService.GetBooks();

            //Assert
            repositoryMock.Verify(x => x.GetBooks(), Times.Once);
        }

        [TestMethod]
        public void RemoveTest_PassValidId_ShouldCallRepositoryRemoveMethod()
        {
            //Arrange
            var repositoryMock = new Mock<IBookRepository>();
            BookService bookService = new BookService(repositoryMock.Object);
            int id = 1;

            //Act
            bookService.Remove(id);

            //Assert
            repositoryMock.Verify(x => x.Remove(id), Times.Once);
        }

        [TestMethod]
        public void RemoveTest_PassInvalidId_ShouldNotCallRepositoryRemoveMethod()
        {
            //Arrange
            var repositoryMock = new Mock<IBookRepository>();
            BookService bookService = new BookService(repositoryMock.Object);
            int id = 0;

            //Act
            bookService.Remove(id);

            //Assert
            repositoryMock.Verify(x => x.Remove(id), Times.Never);
        }

        [TestMethod]
        public void UpdateBookTest_PassValidBook_ShouldUpdateBookInRepository()
        {
            // Arrange
            var repositoryMock = new Mock<IBookRepository>();
            BookService bookService = new BookService(repositoryMock.Object);
            var bookMock = new Mock<Book>();

            // Act
            bookService.Update(bookMock.Object);

            //Assert
            repositoryMock.Verify(x => x.Update(bookMock.Object), Times.Once);
        }

        [TestMethod]
        public void UpdateBookTest_PassNull_ShouldNotUpdateBookInRepository()
        {
            // Arrange
            var repositoryMock = new Mock<IBookRepository>();
            BookService bookService = new BookService(repositoryMock.Object);

            // Act
            bookService.Update(null);

            //Assert
            repositoryMock.Verify(x => x.Update(It.IsAny<Book>()), Times.Never);
        }
    }
}
