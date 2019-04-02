using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;

namespace Lab2.Models
{
    public class BookRepository : IRepository<Books>
    {
        private readonly List<Books> bookList;
        private IFileWorker obb1;

        public BookRepository(IFileWorker obb)
        {
            obb1 = obb;
            string path = HttpContext.Current.Server.MapPath("~/App_Data/Output2.json");

            try
            {
                bookList = new List<Books>(obb1.ReadFromJsonFile<List<Books>>(path));
            }
            catch
            {
                bookList = new List<Books>();
            }
            finally { }
        }

        public Books Get(int id)
        {
            var bookGot = bookList.FirstOrDefault(x => x.Id == id);
            if (bookGot != null)
            {
                return bookGot;
            }

            throw new Exception("Book with such id not found");
        }
        public void Add(Books book)
        {
            bookList.Add(book);
        }
        public void Edit(Books book)
        {
            Remove(book.Id);
            Add(book);
        }
        public void Remove(int id)
        {
            Books forDel = Get(id);
            bookList.Remove(forDel);
        }
        public void Save()
        {
            string path = HttpContext.Current.Server.MapPath("~/App_Data/Output2.json");
            obb1.WriteToJsonFile<List<Books>>(path, bookList);
        }
    }
}