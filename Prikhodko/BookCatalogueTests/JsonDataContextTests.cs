using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookCatalogue;
using System.IO;
using System.Collections.Generic;

namespace BookCatalogueTests
{
    [TestClass]
    public class JsonDataContextTests
    {
        [TestMethod]
        public void Ctor_NoParameters_ShouldReturnObject()
        {
            var dataContext = new JsonDataContextTests();
            Assert.IsNotNull(dataContext);
        }

        [TestMethod]
        public void LoadData_DataExists_ShouldReturnCollection()
        {
            //Arrange
            var dataContext = new JsonDataContext<Book>("books.json");
            var books = new List<Book>();
            var book = new Book();
            book.Id = 1;
            book.Title = "Hello";
            book.Author = "World";
            book.DateOfissue = 1984;
            books.Add(book);
            dataContext.Save(books);

            //Act
            IEnumerable<Book> actual = dataContext.LoadData();

            //Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void Save_EmptyList_ShouldDeleteFile()
        {
            //Arrange
            var dataContext = new JsonDataContext<Book>("books.json");
            if(!File.Exists("books.json"))
            {
                File.Create("books.json");
            }

            //Act
            dataContext.Save(null);

            //Assert
            bool fileExists = File.Exists("books.json");
            Assert.IsFalse(fileExists);
        }
    }
}
