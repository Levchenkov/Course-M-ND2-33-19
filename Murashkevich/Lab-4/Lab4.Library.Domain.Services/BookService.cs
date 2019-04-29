using System.Collections.Generic;
using AutoMapper;
using Lab4.Library.Data.Contracts;
using Lab4.Library.Data.Contracts.Entities;
using Lab4.Library.Domain.Contracts;
using Lab4.Library.Domain.Contracts.ViewModel;

namespace Lab4.Library.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public BookViewModel Get(int id)
        {
            Book book = _unitOfWork.Get<Book>(id);
            BookViewModel result = Mapper.Map<BookViewModel>(book);
            return result;
        }

        public IEnumerable<BookViewModel> GetAll()
        {
            IEnumerable<Book> books = _unitOfWork.GetAll<Book>();
            IEnumerable<BookViewModel> result = Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(books);
            return result;
        }

        public void Add(BookViewModel entity)
        {
            Book book = new Book();
            Mapper.Map(entity, book);
            _unitOfWork.Add(book);
            _unitOfWork.SaveChange();
        }

        public void Update(BookViewModel entity)
        {
            Book book = new Book();
            Mapper.Map(entity, book);
            _unitOfWork.Update(book);
            _unitOfWork.SaveChange();
        }

        public void Delete(int id)
        {
            _unitOfWork.Delete<Book>(id);
            _unitOfWork.SaveChange();
        }
    }
}
