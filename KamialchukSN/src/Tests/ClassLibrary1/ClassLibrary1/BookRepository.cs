using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace ClassLibrary
{
    public class BookRepository : IRepository
    {
        public IList<Book> Data { get; private set; }

        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Book>));

        internal object IndexOf(Book change_book)
        {
            throw new NotImplementedException();
        }

        public BookRepository()
        {
            Data = new List<Book>
            {
                new Book { Id = 1, Title = "Title1" },
                new Book { Id = 2, Title = "Title2" },
                new Book { Id = 3, Title = "Title3" },
                new Book { Id = 4, Title = "Title4" },
                new Book { Id = 5, Title = "Title5" },
            };
        }

        public void SaveBookRepository()
        {
            using (FileStream fs = new FileStream("BookRepository.json", FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, Data);
            }
        }

        public void OpenBookRepository()
        {
            using (FileStream fs = new FileStream("BookRepository.json", FileMode.OpenOrCreate))
            {
                Data = (List<Book>)jsonFormatter.ReadObject(fs);
            }
        }
    }
}