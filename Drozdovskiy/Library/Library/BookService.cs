using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace Library
{
    public class BookService : IBookService<Book>
    {
        private readonly IList<Book> catalog;
        private readonly IFileHandler fileHandler;
        public BookService(IFileHandler fileHandler)
        {
            this.fileHandler = fileHandler;
            catalog = fileHandler.Load().ToList();
            Console.Clear();
        }

        public void ShowCatalog()
        {
            for (int i = 0; i < catalog.Count; i++)
                Console.WriteLine(catalog.ElementAt(i).Id + " " + catalog.ElementAt(i).Title + " " + catalog.ElementAt(i).Pages);
            Console.WriteLine("Press any key");
            Console.ReadKey();
            Console.Clear();
        }
        public Book Get(int id)
        {
            var result = catalog.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                return result;
            }
            throw new Exception("Element not found");
        }

        public void Add(Book entity)
        {
            catalog.Add(entity);
            SaveChanges();
        }
        public void Remove(int id)
        {
            var book = Get(id);
            catalog.Remove(book);
            SaveChanges();
        }
        public void Change(Book entity)
        {
            Remove(entity.Id);
            Add(entity);
            SaveChanges();
        }
        public void SaveChanges()
        {
            fileHandler.Save(catalog.ToList());
        }
    }
}
