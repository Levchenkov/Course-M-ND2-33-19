using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLibraryCRUD;
using Moq;

namespace UnitTestBookLibrary
{
    [TestClass]
    public class BookLibraryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var bookId = 1;
            //initialization
            var bookRepositoryMock = new Mock<ILibrary>();
            bookRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(new Book { Id = bookId, Title = "qwe" });

            var subject = new BookService(bookRepositoryMock.Object); // mock

            //call
            var result = subject.Get(bookId);


            //verification
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);

            bookRepositoryMock.Verify(x => x.Get(It.IsAny<int>()), Times.Once); //spy

        }
    }
}
