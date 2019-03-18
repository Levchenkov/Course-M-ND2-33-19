using BookCatalogJSON;
using System;
using Xunit;

namespace XUnitTestProject2
{
    public class BookCatalogTests
    {
        [Fact]
        public void Test1()
        {
            //arange
            Book testBook = new Book("test",1000,"test");
            //act
            var name = "test";
            //assert
            Assert.Equal(name, testBook.Name);
        }
        [Fact]
        public void Test2()
        {
            //arange
            Book testBook = new Book("test", 1000, "test");
            //act
            var name = "test1";
            //assert
            Assert.Equal(name, testBook.Year.ToString());
        }
    }
}
