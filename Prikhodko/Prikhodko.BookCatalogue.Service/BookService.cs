using System.Collections.Generic;
using Prikhodko.BookCatalogue.Data.Contracts.Interfaces;
using Prikhodko.BookCatalogue.Service.Contracts.Interfaces;
using Prikhodko.BookCatalogue.Service.Contracts.Models;
using Prikhodko.BookCatalogue.Data.Contracts.Models;
using System.Linq;
using AutoMapper;

namespace Prikhodko.BookCatalogue.Service
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Book> repository;
        private readonly ILanguageService languageService;

        public BookService(IUnitOfWork unitOfWork, IRepository<Book> repository, ILanguageService languageService)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.languageService = languageService;
        }

        public void Add(BookViewModel item)
        {
            if(item == null)
            {
                return;
            }
            else
            {
                Book book = Mapper.Map<Book>(item);
                var allLanguages = languageService.GetAll();
                var languages = new List<Language>();
                foreach (var languageCode in item.AvailableLanguages)
                {
                    var language = allLanguages?.First(x => x.Code == languageCode);
                    if (language != null)
                    {
                        languages.Add(language);
                    }
                }
                book.AvailableLanguages = languages;
                repository.Add(book);
               unitOfWork.SaveChanges();
            }
        }

        public BookViewModel Get(int id)
        {
            if(id <= 0)
            {
                return null;
            }
            else
            {
                Book book = repository.Get(id);
                BookViewModel bookViewModel = Mapper.Map<BookViewModel>(book);
                return bookViewModel;
            }
        }

        public IEnumerable<BookViewModel> GetAll()
        {
            var books = repository.GetAll();
            var result = new List<BookViewModel>();
            foreach(var book in books)
            {
                result.Add(Mapper.Map(book, new BookViewModel()));
            }
            return result;
        }

        public void Remove(int id)
        {
            if (id <= 0)
            {
                return;
            }
            else
            {
                repository.Remove(id);
                unitOfWork.SaveChanges();
            }
        }

        public void Update(BookViewModel item)
        {
            if (item == null)
            {
                return;
            }
            else
            {
                Book book = Mapper.Map<Book>(item);
                repository.Update(book);
                unitOfWork.SaveChanges();
            }
        }
    }
}
