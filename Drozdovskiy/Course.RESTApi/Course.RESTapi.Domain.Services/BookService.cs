using Course.RESTapi.Data.Contracts;
using Course.RESTapi.Domain.Contracts;
using Course.RESTapi.Domain.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Course.RESTapi.Data.Contracts.Entities;

namespace Course.RESTapi.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            unitOfWork.Remove<Book>(id);
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

        public BookViewModel Get(int id)
        {
            Book book = unitOfWork.Get<Book>(id);
            var result = Mapper.Map<BookViewModel>(book);
            return result;
        }

        public void Save(BookViewModel viewModel)
        {
            Book book = new Book();
            Mapper.Map(viewModel, book);
            unitOfWork.Add(book);
            unitOfWork.SaveChanges();
        }
    }
}
