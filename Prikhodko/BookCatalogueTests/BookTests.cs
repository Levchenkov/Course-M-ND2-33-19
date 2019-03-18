using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using BookCatalogue;

namespace BookCatalogueTests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void ToString_PassBook_ShouldReturnString()
        {
            //Arrange
            var book = new Book();
            book.Id = 1;
            book.Name = "Hello";
            book.Author = "World";
            book.YearOfIssue = 1984;
            var expected = "ID: 1; Name: \"Hello\"; by World (1984)";

            //Act
            var actual = book.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
