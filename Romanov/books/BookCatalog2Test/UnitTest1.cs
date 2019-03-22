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
        public void Ctor_Must_Include_Smth()
        {
            var result = new Catalog() { Books = new List<Book>() };
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Get_BookExist()
        {
            var mockjsonFile = new Mock<IBookCatalogPossibility<Book>>();
            mockjsonFile.Setup(x => x.GetT(1)).Returns(new Book { Id = 1, Title = "TestMockTitleForBook" });
            
        }
        [TestMethod]
        public void DelTest()
        {
            var mock = new Mock<Catalog>();
            
            var s = mock.SetupAllProperties();
            s.Setup(x => x.Compare(1, 2)).Returns(false);

        }
    }
}
