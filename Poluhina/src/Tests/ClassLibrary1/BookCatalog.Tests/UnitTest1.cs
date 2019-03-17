﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace BookCatalog.Tests
{
    [TestClass]
    public class BookRepositoryTest
    {
        [TestMethod]
        public void Add_CalledAtLeastOnce_True()
        {
            // Arrange
            var mock = new Mock<BookRepository>();
            mock.Setup(a => a.Add(It.IsAny<Book>())).Verifiable();
            var actual = mock.Object;
            // Act
            actual.Add(new Book());
            // Assert
            mock.Verify();
        }
        [TestMethod]
        public void Change_CalledAtLeastOnce_True()
        {
            // Arrange
            var mock = new Mock<BookRepository>();
            mock.Setup(a => a.Change(It.IsAny<int>(), It.IsAny<Book>())).Verifiable();
            var actual = mock.Object;
            // Act
            actual.Change(4, new Book());
            // Assert
            mock.Verify();
        }
        [TestMethod]
        public void Remove_CalledAtLeastOnce_True()
        {
            // Arrange
            var mock = new Mock<BookRepository>();
            mock.Setup(a => a.Remove(It.IsAny<int>())).Verifiable();
            var actual = mock.Object;
            // Act
            actual.Remove(4);
            // Assert
            mock.Verify();
        }
        [TestMethod]

        public void GetCount_ListBookCount_4()
        {
            // Arrange
            var mock = new Mock<BookRepository>();
            mock.Setup(a => a.GetCount()).Returns(() => 4);
            var actual = mock.Object;
            // Act
            int count = actual.GetCount();
            // Assert
            Assert.AreEqual(4, count);
        }
    }
    [TestClass]
    public class BookInitializationTest
    {
        [TestMethod]
        public void Property_listBooks_Value_IsNotNull()
        {
            // Arrange
            var mock = new Mock<BookInitialization>();
            mock.Setup(a => a.listBooks).Returns(() => new List<Book>());
            var actual = mock.Object;
            // Act
            var list = actual.listBooks;
            // Assert
            Assert.IsNotNull(list);
        }
    }
}