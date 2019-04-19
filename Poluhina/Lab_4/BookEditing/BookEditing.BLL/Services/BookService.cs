using AutoMapper;
using BookEditing.BLL.DTO;
using BookEditing.BLL.Interfaces;
using BookEditing.DAL.Entities;
using BookEditing.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BookEditing.BLL.Services
{
    public class BookService : IBookService<BookDTO>
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public BookService(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }
        public IEnumerable<BookDTO> GetList()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Book>, List<BookDTO>>(UnitOfWork.Books.GetList());
        }
        public void Add(BookDTO newBook)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, Book>()).CreateMapper();
            var book = mapper.Map<BookDTO, Book>(newBook);
            UnitOfWork.Books.Add(book);
            UnitOfWork.Save();
        }
        public void Change(BookDTO book)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, Book>()).CreateMapper();
            var bookDAL = mapper.Map<BookDTO, Book>(book);
            UnitOfWork.Books.Change(bookDAL);
            UnitOfWork.Save();
        }
        public void Remove(int id)
        {
            UnitOfWork.Books.Remove(id);
            UnitOfWork.Save();
        }
        public BookDTO Get(int id)
        {
            var book = UnitOfWork.Books.Get(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>()).CreateMapper();
            var bookDAL = mapper.Map<Book, BookDTO>(book);
            return bookDAL;
        }
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
