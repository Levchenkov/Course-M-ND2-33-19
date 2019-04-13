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
            var book=mapper.Map<BookDTO, Book>(newBook);

            //var languagesForDataLayer = newBook.Languages.Select(x => new Language() { Id = x.Id, Name = x.Name }).ToList();
            //var book = new Book
            //{
            //    Author = newBook.Author,
            //    Created = newBook.Created,
            //    DeliveryRequred = newBook.DeliveryRequred,
            //    Description = newBook.Description,
            //    Genre = newBook.Genre,
            //    IsPaper = newBook.IsPaper,
            //    Title = newBook.Title,
            //    Id = newBook.Id,
            //    Languages = languagesForDataLayer
            //};
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
            //var languagesOfDataLayer = book.Languages.Select(x => new LanguageDTO() { Id = x.Id, Name = x.Name }).ToList();
            //return new BookDTO
            //{
            //    Author = book.Author,
            //    Created = book.Created,
            //    DeliveryRequred = book.DeliveryRequred,
            //    Description = book.Description,
            //    Genre = book.Genre,
            //    IsPaper = book.IsPaper,
            //    Title = book.Title,
            //    Id = book.Id,
            //    Languages = languagesOfDataLayer
            //};
            return bookDAL;
        }
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
