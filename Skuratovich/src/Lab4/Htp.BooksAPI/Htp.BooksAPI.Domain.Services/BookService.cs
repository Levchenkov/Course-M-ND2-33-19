using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Htp.BooksAPI.Data.Contracts;
using Htp.BooksAPI.Data.Contracts.Entities;
using Htp.BooksAPI.Domain.Contracts;
using Htp.BooksAPI.Domain.Contracts.ViewModels;

namespace Htp.BooksAPI.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper mapper;
        //private readonly IBookRepository bookRepository;

        private readonly IUnitOfWork unitOfWork;

        //public BookService(IMapper mapper, IBookRepository bookRepository)
        public BookService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            //this.bookRepository = bookRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<BookViewModel> GetAll()
        {
            //IEnumerable<Book> books = bookRepository.GetAll();
            IEnumerable<Book> books = unitOfWork.BookRepository.GetAll();
            var result = mapper.Map<IEnumerable<BookViewModel>>(books);
            return result;
        }

        public async Task<BookViewModel> GetAsync(int id)
        {
            //Book book = bookRepository.Get(Id);
            //Book book = unitOfWork.BookRepository.Get(id);
            var book = await unitOfWork.BookRepository.GetAsync(id);

            var result = mapper.Map<BookViewModel>(book);
            return result;
        }

        public void Add(BookViewModel bookViewModel)
        {
            var result = mapper.Map<Book>(bookViewModel);

            var CreatedBy = unitOfWork.Repository<AppUser>().Get(bookViewModel.CreatedByUserID);
            result.CreatedBy = CreatedBy;
            result.UpdatedBy = null;

            using (var transaction = unitOfWork.BeginTransaction())
            {
                try
                {
                    //bookRepository.Add(result);
                    //bookRepository.Save();
                    unitOfWork.BookRepository.Add(result);
                    unitOfWork.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<bool> EditAsync(BookViewModel bookViewModel)
        {   
            using (var transaction = unitOfWork.BeginTransaction())
            {
                try
                {
                    Book book = await unitOfWork.BookRepository.GetAsync(bookViewModel.Id);
                    mapper.Map(bookViewModel, book);

                    if (book.UpdatedBy != null)
                    {
                        var updatedBefore = unitOfWork.Repository<AppUser>().Get(book.UpdatedBy.Id);
                        updatedBefore.UpdatedBooks.Remove(book);
                        unitOfWork.Repository<AppUser>().Update(updatedBefore);
                        var x = await unitOfWork.SaveChangesAsync();
                    }

                    var UpdatedBy = unitOfWork.Repository<AppUser>().Get(bookViewModel.UpdatedByUserID);
                    book.UpdatedBy = UpdatedBy;

                    unitOfWork.BookRepository.Update(book);
                    var y = await unitOfWork.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                    //return false;
                }
            }
        }

        public async void DeleteAsync(int id)
        {
            using (var transaction = unitOfWork.BeginTransaction())
            {
                try
                {
                    //Book book = bookRepository.Get(Id);
                    //bookRepository.Delete(book);
                    //bookRepository.Save();
                    Book book = await unitOfWork.BookRepository.GetAsync(id);

                    unitOfWork.BookRepository.Delete(book);
                    var x = await unitOfWork.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}