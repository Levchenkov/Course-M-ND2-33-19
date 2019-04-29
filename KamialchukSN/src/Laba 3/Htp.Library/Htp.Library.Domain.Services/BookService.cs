using AutoMapper;
using Htp.Library.Data.Contracts;
using Htp.Library.Data.Contracts.Entities;
using Htp.Library.Domain.Contracts;
using Htp.Library.Domain.Contracts.ViewModels;
using System.Collections.Generic;

namespace Htp.Library.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public BookViewModel Get(int id)
        {
            var book = unitOfWork.Get<Book>(id);
            var result = Mapper.Map<BookViewModel>(book);
            return result;
        }

        public IEnumerable<BookViewModel> GetAll()
        {
            var books = unitOfWork.GetAll<Book>();
            var result = new List<BookViewModel>();
            foreach (var book in books)
            {
                result.Add(Mapper.Map(book, new BookViewModel()));
            }
            return result;
        }

        public void Add(BookViewModel viewModel)
        {
            var transaction = unitOfWork.BeginTransaction();
            var book = Mapper.Map(viewModel, new Book());
            unitOfWork.Add(book);
            unitOfWork.SaveChanges();
            transaction.Commit();
        }

        public void Delete(int id)
        {
            var transaction = unitOfWork.BeginTransaction();
            unitOfWork.Remove<Book>(id);
            unitOfWork.SaveChanges();
            transaction.Commit();
        }

        public void Edit(int id, BookViewModel viewModel)
        {
            var transaction = unitOfWork.BeginTransaction();
            var book = Mapper.Map(viewModel, new Book());
            unitOfWork.Edit(id, book);
            unitOfWork.SaveChanges();
            transaction.Commit();
        }
    }
}