using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookCatalog2;
using System.Collections.Generic;
using Moq;

namespace BookCatalog2Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            Catalog catalog = new Catalog();
            catalog.Books = new List<Catalog.Book>();
           // var testBook = new Catalog.Book() { Title = "test", Id = 123 };
            var mockBook = new Mock<Catalog.Book>();
            //act
            Catalog.Add(catalog, mockBook);
            //assert
            Assert.AreEqual(123, catalog.Books[0].Id);
        }
        [TestMethod]
        public void TestMethod2()
        {
            //arrange
            Catalog catalog = new Catalog();
            catalog.Books = new List<Catalog.Book>();
            var testBook = new Catalog.Book() { Title = "test", Id = 123 };
            //act
            Catalog.Add(catalog, testBook);
            //assert
            Assert.AreEqual("test", catalog.Books[0].Title);
        }
    }
}
