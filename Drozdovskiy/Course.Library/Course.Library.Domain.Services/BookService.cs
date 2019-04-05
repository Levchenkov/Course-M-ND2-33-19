using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Course.Library.Data.Contracts;
using Course.Library.Data.Contracts.Entities;
using Course.Library.Domain.Contracts;
using Course.Library.Domain.Contracts.ViewModels;

namespace Course.Library.Domain.Services
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
            Book book = unitOfWork.Get<Book>(id);
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

        public void Delete(int id)
        {
            unitOfWork.Remove<Book>(id);
        }
        public IList<string> GetGenres()
        {
            var genres = unitOfWork.GetGenres();
            var result = new List<string>();
            for (int i = 0; i < genres.Count(); i++)
            {
                result.Add(genres.ElementAt(i).Title);
            }

            return result;
        }

        public IList<string> GetLanguages()
        {
            var languages = unitOfWork.GetLanguages();
            var result = new List<string>();
            for (int i = 0; i < languages.Count(); i++)
            {
                result.Add(languages.ElementAt(i).Title);
            }

            return result;
        }
        public void Save(BookViewModel viewModel)
        {
            var transaction = unitOfWork.BeginTransaction();
            Book book = new Book();
            Mapper.Map(viewModel, book);
            unitOfWork.Add(book);
            unitOfWork.SaveChanges();
            transaction.Commit();
        }

    }
}
