using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookCatalog2;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
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
        public void Get_shouldBe_return_smth()
        {
            Catalog catalog = new Catalog() { };
            catalog.Add(new Book() { Id = 1, Title = "One" });
            catalog.Add(new Book() { Id = 2, Title = "two" });
            var indexForGet = 0;
            Assert.IsNotNull(catalog.GetT(indexForGet));
        }

    }
}
