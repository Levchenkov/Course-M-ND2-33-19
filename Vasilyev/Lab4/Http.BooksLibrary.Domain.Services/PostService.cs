using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Http.BooksLibrary.Domain.Contracts;
using Http.BooksLibrary.Domain.Contracts.ViewModels;
using Http.BooksLibrary.Data.Contracts;
using Http.BooksLibrary.Data.Contracts.Entities;

namespace Http.BooksLibrary.Domain.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public BookViewModel Get(int id)
        {
            Book book = unitOfWork.Get<Book>(id);
            var result = Mapper.Map<BookViewModel>(book);
            return result;
        }

        public IList<BookViewModel> GetAll()
        {
            IList<Book> books = unitOfWork.GetAll<Book>();
            var result = Mapper.Map<List<BookViewModel>>(books);
            return result;
        }

        public void Add(BookViewModel viewModel)
        {
            viewModel.Id = unitOfWork.GetAll<Book>().OrderBy(x => x.Id).Last().Id + 1;
            Book book = new Book();
            Mapper.Map(viewModel, book);
            unitOfWork.Add(book);
        }

        public void Save(BookViewModel viewModel)
        {
            using (var transaction = unitOfWork.BeginTransaction())
            {
                try
                {
                    Book book = unitOfWork.Get<Book>(viewModel.Id);
                    if (book.LongVersion != viewModel.LongVersion)
                    {
                        throw new Exception("Version redact error");
                    }
                    Mapper.Map(viewModel, book);
                    unitOfWork.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Delete(int id)
        {
            using (var transaction = unitOfWork.BeginTransaction())
            {
                try
                {
                    unitOfWork.Delete<Book>(id);
                    unitOfWork.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}