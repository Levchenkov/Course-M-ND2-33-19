using System.Collections.Generic;
using AutoMapper;
using Lab.Library.Data.Contracts;
using Lab.Library.Data.Contracts.Entities;
using Lab.Library.Domain.Contracts;
using Lab.Library.Domain.Contracts.ViewModels;

namespace Lab.Library.Domain.Services
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
            var result = Mapper.Map<BookViewModel>(book);
            return result;
        }

        public void Add(BookViewModel viewModel)
        {
            var transaction = _unitOfWork.BeginTransaction();
            Book book = new Book();
            Mapper.Map(viewModel, book);
            _unitOfWork.Add(book);
            _unitOfWork.SaveChange();
            transaction.Commit();
        }
        
        public IEnumerable<BookViewModel> GetAll()
        {
            IEnumerable<Book> books = _unitOfWork.GetAll<Book>();
            IEnumerable<BookViewModel> result = Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(books);
            return result;
        }

        public void Remove(int id)
        {
            _unitOfWork.Remove<Book>(id);
            _unitOfWork.SaveChange();
        }

        public void Update(BookViewModel viewModel)
        {
            Book book = new Book();
            Mapper.Map(viewModel, book);
            _unitOfWork.Update(book);
            _unitOfWork.SaveChange();
        }
    }
}
