using BookEditing.Models;
using System.Collections.Generic;
using System.IO;

namespace BookEditing.Additional_methods
{
    public class BookRepository : IRepository<Book>
    {
        private List<Book> listBooks { get; set; }
        private JsonFormat jsonFormatter;
        public BookRepository(JsonFormat jsonFormatter)
        {
            this.jsonFormatter = jsonFormatter;
            if (File.Exists(@"D:\book.json"))
            {
                listBooks = jsonFormatter.Deserialize(listBooks);
            }
            else
            {
                listBooks = new List<Book>
            {
                new Book{
                    Id =1,
                    Title ="The Master and Margarita",
                    Description ="No description",
                    Author = "Michael Bulgakov",
                    Created=new System.DateTime(1992,2,24),
                    Genre ="novel" ,
                    IsPaper =true,
                    Languages =new List<string>{"Russian","English"},
                    DeliveryRequred =true },
                new Book{
                    Id =2,
                    Title ="Asya",
                    Description ="No description",
                    Author = "Ivan Turgenev",
                    Created=new System.DateTime(1956,5,27),
                    Genre ="novel" ,
                    IsPaper =true,
                    Languages =new List<string>{"Russian","English"},
                    DeliveryRequred =true },
            };
                jsonFormatter.Serialize(listBooks);
            }
        }
        public void SerializeAndSave()
        {
            jsonFormatter.Serialize(listBooks);
        }
        public virtual void Add(Book book)
        {
                listBooks.Add(book);
        }
        public  List<Book> Change(int id, Book newBook)
        {
            var book = listBooks?.Find(x => x.Id == id);
            var index= listBooks.FindIndex(x => x.Id == id);
            if (book != null)
            {
                book = newBook;
                listBooks[index] = book;
            }
            return listBooks;
        }
        public virtual void Remove(int id)
        {
            var book = listBooks?.Find(x => x.Id == id);
            if (book != null)
                listBooks.Remove(book);
        }
        public IEnumerable<Book> GetBooks()
        {
            return listBooks;
        }
    }
}