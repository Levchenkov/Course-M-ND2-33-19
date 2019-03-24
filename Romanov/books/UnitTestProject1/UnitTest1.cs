using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookCatalog2;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DellAll_Should_Return_True()
        {
            var mock = new Mock<IBookCatalogPossibility<Book>>();
            mock.Setup(x => x.DelAll()).Returns(() => true);
            var act = mock.Object;
            bool b2 = true;
            Assert.AreEqual(b2, act.DelAll());
        }
        [TestMethod]
        public void Compare_Should_Return_True_()
        {
            var mock = new Mock<IBookCatalogPossibility<Book>>();
            mock.Setup(x => x.Compare(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            var act = mock.Object;
            bool b2 = true;
            Assert.AreEqual(b2, act.Compare(1,23));
        }
        [TestMethod]
        public void Get_Should_Be_Is_Not_Null()
        {
            var mock = new Mock<IBookCatalogPossibility<Book>>();
            mock.Setup(x => x.GetT(It.IsAny<int>())).Returns(new Book());
            var act = mock.Object;
            var testGet = act.GetT(3);
            Assert.IsNotNull(testGet);
        }
        [TestMethod]
        public void Add_Should_Be_Return_Count()
        {
            var mock = new Mock<IBookCatalogPossibility<Book>>();
            mock.Setup(x => x.Add(It.IsAny<Book>())).Returns(1);
            var act = mock.Object;
            int testAdd = act.Add(new Book());
            int t = 1;
            Assert.AreEqual(t, testAdd);
        }
        [TestMethod]
        public void Compare_Should_Return_false()
        {
            Catalog catalog = new Catalog() { };
            catalog.Add(new Book() { Id = 1, Title = "One" });
            catalog.Add(new Book() { Id = 2, Title = "two" });
            bool b = false;
            Assert.AreEqual(b, catalog.Compare(0, 1));
        }

        [TestMethod]
        public void TestAdd()
        {
            // Arrange
            var mock = new Mock<Catalog>();
            var act = mock.Object;
            // Act
            act.Add(new Book());
            act.Add(new Book());
            // Assert
            Assert.AreEqual(2, act.Books.Count);
        }
        [TestMethod]
        public void TestDel()
        {
            // Arrange
            var mock = new Mock<Catalog>();
            var act = mock.Object;
            act.Add(new Book());
            act.Add(new Book());
            // Act
            act.Del(0);
            // Assert
            Assert.AreEqual(1,act.Books.Count);
        }
    }
}
