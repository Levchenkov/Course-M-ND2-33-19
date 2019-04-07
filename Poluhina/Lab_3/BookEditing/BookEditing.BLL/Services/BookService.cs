using AutoMapper;
using BookEditing.BLL.DTO;
using BookEditing.BLL.Interfaces;
using BookEditing.DAL.Entities;
using BookEditing.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEditing.BLL.Services
{
   public class BookService : IBookService<BookDTO>
    {
        IUnitOfWork UnitOfWork { get; set; }

        public BookService(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }
        //public MultiSelectList list()
        //{
        //    var languages = db.Languages.Include(p => p.Books).ToList();
        //    var selectList = new MultiSelectList(languages, "Id", "Name");
        //    return selectList;
        //}
        public IEnumerable<BookDTO> GetList()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Book>, List<BookDTO>>(UnitOfWork.Books.GetList());         
        }
        public void Add(BookDTO newBook)
        {
            var book = new Book
            {
                Author = newBook.Author,
                Created = newBook.Created,
                DeliveryRequred = newBook.DeliveryRequred,
                Description = newBook.Description,
                Genre = newBook.Genre,
                IsPaper = newBook.IsPaper,
                Title = newBook.Title,
                Id = newBook.Id
            };
            UnitOfWork.Books.Add(book);
            UnitOfWork.Save();
        }
        public void Change(BookDTO book)
        {
            //Book bookCreate = UnitOfWork.Books.Get(bookDTO.Id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, Book>()).CreateMapper();           
            var bookDAL = Mapper.Map<BookDTO, Book>(book);
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
            return new BookDTO
            {
                Author = book.Author,
                Created = book.Created,
                DeliveryRequred = book.DeliveryRequred,
                Description = book.Description,
                Genre = book.Genre,
                IsPaper = book.IsPaper,
                Title = book.Title,
                Id = book.Id
            };
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
