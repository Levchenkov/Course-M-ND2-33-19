using System;
using System.Collections.Generic;
using System.Linq;
using Lab2.DAL.Entities;
using Lab2.DAL.Interfaces;

namespace Lab2.DAL.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        // Context
        private readonly IList<Book> data;
        private readonly IFileHandler fileHandler;

        // Constructor
        public BookRepository(IFileHandler fileHandler)
        {
            this.fileHandler = fileHandler;
            data = fileHandler.Load().ToList();
        }

        // CRUD
        public void Add(Book entity) => data.Add(entity);


        public void Delete(int Id)
        {
            var book = GetByID(Id);
            data.Remove(book);
        }

        public void Edit(Book entity)
        {
            var result = data.FirstOrDefault(x => x.Id == entity.Id);

            if (result != null)
            {
                result = entity;
            }
            else
            {
                throw new Exception("Element not found");
            }
        }

        public List<Book> GetAll()
        {
            return data as List<Book>;
        }

        public Book GetByID(int? id)
        {
            var result = data.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                return result;
            }

            throw new Exception("Element not found");
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        //public void SaveChanges() => fileHandler.Save(data.ToList());
    }
}