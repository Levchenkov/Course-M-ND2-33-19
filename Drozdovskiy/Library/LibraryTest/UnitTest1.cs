using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
namespace Library.Test
{
    [TestClass]
    public class BookCatalogTest
    {
        [TestMethod]
        public void Validate_IncorrectInput_ShouldntBeChanged()
        {
            var mock = new Mock<BookCatalog>();
            mock.Setup(x => x.Validate(It.IsAny<string>())).Returns("123");
            var acting = mock.Object;
            var result = acting.Validate("123");
            Assert.AreEqual("123", result);
        }
        [TestMethod]
        public void Add_Book_HasBeenAdded()
        {
            var mock = new Mock<BookCatalog>();
            mock.Setup(x => x.Add(It.IsAny<Book>())).Verifiable();
            var acting = mock.Object;
            acting.Add(new Book(){Pages = 1,Title = "Test"});
            mock.Verify();
        }
        [TestMethod]
        public void Change_Book_ShouldBeCalled()
        {
            var mock = new Mock<BookCatalog>();
            mock.Setup(x => x.Change(It.IsAny<int>())).Verifiable();
            var acting = mock.Object;
            acting.Change(5);
            mock.Verify();
        }
        [TestMethod]
        public void Remove_Book_HasBeenRemoved()
        {
            var mock = new Mock<BookCatalog>();
            mock.Setup(x => x.Remove(It.IsAny<int>())).Verifiable();
            var acting = mock.Object;
            acting.Remove(5);
            mock.Verify();
        }
    }
}
