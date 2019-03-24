using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookCatalog2
{
    public interface IBookCatalogPossibility<T> where T: class
    {
        int Add(T book);
        void Del(int index);
        T GetT(int index);
        void Edit(T book, int index);
        bool Compare(int indexBookLeft, int indexBookRight);
        bool DelAll();
    }

    public class Book
    {
        public string Title { get; set; }
        public int Id { get; set; }
    }

    public class Catalog : IBookCatalogPossibility<Book>
    {
        public List<Book> Books { get; set; }

        public int Add(Book book)
        {
            Books.Add(book);
            return Books.Count;
        }

        public void Del(int index) => Books.RemoveAt(index);
        public void Edit(Book book, int index) => Books[index] = book;
        public Book GetT(int index) => Books[index];

        public bool Compare(int bookLeft, int bookRight)
        {
            var bookFirst = JsonConvert.SerializeObject(Books[bookLeft]);
            var bookSecond = JsonConvert.SerializeObject(Books[bookRight]);

            return bookFirst == bookSecond;
        }

        public bool DelAll()
        {
            Books.RemoveRange(0, Books.Count);
            if (Books.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Catalog() => Books = new List<Book>();
    }
    
}
