using AutoMapper;
using BookEditing.DAL.Entities;
using BookEditing.DAL.Interfaces;
using BookEditing.WebAPI.Models;
using System.Collections.Generic;

namespace BookEditing.WebAPI.Services
{
    public class BookService : IBookService
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public BookService(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }
        public void Add(BookApiModel newBook)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookApiModel, Book>()).CreateMapper();
            var book = mapper.Map<BookApiModel, Book>(newBook);
            UnitOfWork.Books.Add(book);
            UnitOfWork.Save();
        }

        public void Change(BookApiModel book)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookApiModel, Book>()).CreateMapper();
            var bookDAL = mapper.Map<BookApiModel, Book>(book);
            UnitOfWork.Books.Change(bookDAL);
            UnitOfWork.Save();
        }
        public void Remove(int id)
        {
            UnitOfWork.Books.Remove(id);
            UnitOfWork.Save();
        }
        public BookApiModel Get(int id)
        {
            var book = UnitOfWork.Books.Get(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookApiModel>()).CreateMapper();
            var bookApiModel = mapper.Map<Book, BookApiModel>(book);
            return bookApiModel;
        }
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }

        public IEnumerable<BookApiModel> GetList()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookApiModel>()).CreateMapper();
            return mapper.Map<IEnumerable<Book>, List<BookApiModel>>(UnitOfWork.Books.GetList());
        }
    }
}