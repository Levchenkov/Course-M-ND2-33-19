﻿using BookEditing.DAL.EF;
using BookEditing.DAL.Entities;
using BookEditing.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookEditing.DAL.Repositories
{
    public class DataBookRepository : IDataRepository<Book>/*, IDisposable*/
    {
        private BookContext db;


        public DataBookRepository(BookContext db)
        {
           this.db = db;
           
        }
        //public MultiSelectList list()
        //{
        //    var languages = db.Languages.Include(p => p.Books).ToList();
        //    var selectList = new MultiSelectList(languages, "Id", "Name");
        //    return selectList;
        //}
        public IEnumerable<Book> GetList()
        {
            
            var books = db.Books.Include(p => p.Languages).ToList();
            return books;
        }
        public void Add(Book book)
        {
            db.Books.Add(book);
            db.Entry(book).State = EntityState.Added;
        }
        public void Change(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
        }
        public void Remove(int id)
        {
            var book = db.Books.Find(id);
            if (book != null)
                db.Books.Remove(book);
        }
        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        //protected void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (db != null)
        //        {
        //            db.Dispose();
        //            db = null;
        //        }
        //    }
        //}
        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
        //~DataBookRepository()
        //{
        //    Dispose(false);
        //}
    }
}