using System;
using System.Collections.Generic;
using AutoMapper;
using Htp.Books.Common.Contracts;
using Htp.Books.Data.Contracts;
using Htp.Books.Data.Contracts.Entities;
using Htp.Books.Domain.Contracts;
using Htp.Books.Domain.Contracts.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Htp.Books.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public IHistoryLogHandler<Book> historyLogHandler;

        // TODO: ask about UnitOfWork and Imapper
        public BookService(IUnitOfWork unitOfWork, IMapper mapper, IHistoryLogHandler<Book> historyLogHandler)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

            this.historyLogHandler = historyLogHandler;
        }

        public IEnumerable<BookViewModel> GetAll()
        {
            IEnumerable<Book> books = unitOfWork.GetAll<int, Book>();
            var result = mapper.Map<IEnumerable<BookViewModel>>(books);
            return result;
        }

        public BookViewModel Get(int id)
        {
            Book book = unitOfWork.Get<int, Book>(id);
            Genre genre = unitOfWork.Get<int, Genre>(book.GenreId);
            book.Genre = genre;
            var result = mapper.Map<BookViewModel>(book);

            var languages = unitOfWork.FindByCondition<int, BookLanguage>(x => x.BookId == book.Id);
            result.LanguageIds = new List<int>();
            foreach (var language in languages)
            {
                result.LanguageIds.Add(language.LanguageId); 
            }

            List<HistoryLog> historyLogs = (List<HistoryLog>)unitOfWork.FindByCondition<int, HistoryLog>(x => x.EntityId == book.Id.ToString() && x.EntityType == book.GetType().ToString());

            var count = historyLogs.Count;

            result.HistoryLog = $"{count} version(s)";

            return result;
        }

        public void Add(BookViewModel bookViewModel)
        {
            var result = mapper.Map<Book>(bookViewModel);
            var genre = unitOfWork.Get<int, Genre>(result.GenreId);
            result.Genre = genre;

            using (var transaction = unitOfWork.BeginTransaction())
            {
                try
                {
                    result.BookLanguages = new List<BookLanguage>();
                    if (bookViewModel.LanguageIds != null)
                    {
                        foreach (int languageId in bookViewModel.LanguageIds)
                        {
                            var bookLanguage = new BookLanguage() { BookId = result.Id, LanguageId = languageId };
                            result.BookLanguages.Add(bookLanguage);
                            unitOfWork.Add<int, BookLanguage>(bookLanguage);
                        }
                    }
                    unitOfWork.Add<int, Book>(result);
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

        public void Edit(BookViewModel bookViewModel)
        {
            Book book = unitOfWork.Get<int, Book>(bookViewModel.Id);
            mapper.Map(bookViewModel, book);

            book.Genre = unitOfWork.Get<int, Genre>(bookViewModel.GenreId);

            using (var transaction = unitOfWork.BeginTransaction())
            {
                try
                {
                    if (book.LongRowVersion != bookViewModel.LongRowVersion)
                    {
                        throw new Exception("DbUpdateConcurrencyException");
                    }

                    var languages = unitOfWork.GetAll<int, Language>();
                    List<BookLanguage> bookLanguages = (List<BookLanguage>)unitOfWork.FindByCondition<int, BookLanguage>(x => x.BookId == book.Id);

                    if (bookViewModel.LanguageIds == null)
                    {
                        foreach (var bookLanguage in bookLanguages)
                        {
                            unitOfWork.Delete<int, BookLanguage>(bookLanguage);
                        }
                    }
                    else
                    {
                        foreach (var language in languages)
                        {
                            if (bookViewModel.LanguageIds.Contains(language.Id))
                            {
                                if (bookLanguages.Exists(x => x.LanguageId == language.Id))
                                {
                                    unitOfWork.Update<int, BookLanguage>(bookLanguages.Find(x => x.LanguageId == language.Id));
                                }
                                else
                                {
                                    unitOfWork.Add<int, BookLanguage>(new BookLanguage() { BookId = book.Id, LanguageId = language.Id });
                                }
                            }
                            else
                            {
                                if (bookLanguages.Exists(x => x.LanguageId == language.Id))
                                {
                                    unitOfWork.Delete<int, BookLanguage>(bookLanguages.Find(x => x.LanguageId == language.Id));
                                }
                            }
                        } 
                    }
                    unitOfWork.Update<int, Book>(book);
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

        public IEnumerable<HistoryLogViewModel> GetHistoryLogs(int id)
        {
            IEnumerable<HistoryLog> historyLogs = unitOfWork.FindByCondition<int, HistoryLog>(x => x.EntityId == id.ToString() && x.EntityType == typeof(Book).ToString());

            var result = mapper.Map<IEnumerable<HistoryLogViewModel>>(historyLogs);

            var genres = GetGenres();
            var languages = GetLanguages();

            foreach (var historyLog in result)
            {
                var currentBook = historyLogHandler.Deserialize(historyLog.Actually);
                historyLog.CurrentBook = mapper.Map<Book, BookViewModel>(currentBook);
                historyLog.CurrentBook.LanguageIds = new List<int>();
                if (currentBook.BookLanguages != null)
                {
                    foreach (var language in currentBook.BookLanguages)
                    {
                        historyLog.CurrentBook.LanguageIds.Add(language.LanguageId);
                    }
                }
                historyLog.CurrentBook.Genres = genres;
                historyLog.CurrentBook.Languages = languages;

                var originBook = historyLogHandler.Deserialize(historyLog.Origin);
                historyLog.OriginBook = mapper.Map<Book, BookViewModel>(historyLogHandler.Deserialize(historyLog.Origin));
                historyLog.OriginBook.LanguageIds = new List<int>();
                if (originBook.BookLanguages != null)
                {
                    foreach (var language in originBook.BookLanguages)
                    {
                        historyLog.OriginBook.LanguageIds.Add(language.LanguageId);
                    }
                }
                historyLog.OriginBook.Genres = genres;
                historyLog.OriginBook.Languages = languages;
            }
            return result;
        }

        public void Delete(int Id)
        {
            Book book = unitOfWork.Get<int, Book>(Id);
            using (var transaction = unitOfWork.BeginTransaction())
            {
                try
                {
                    unitOfWork.Delete<int, Book>(book);
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

        public List<SelectListItem> GetGenres()
        {
            var genres = new List<SelectListItem>();
            foreach (var ganre in unitOfWork.GetAll<int, Genre>())
            {
                genres.Add(new SelectListItem() { Value = ganre.Id.ToString(), Text = ganre.Title });
            }
            return genres;
        }

        public List<SelectListItem> GetLanguages()
        {
            var languages = new List<SelectListItem>();
            foreach (var languagere in unitOfWork.GetAll<int, Language>())
            {
                languages.Add(new SelectListItem() { Value = languagere.Id.ToString(), Text = languagere.Title });
            }
            return languages;
        }
    }
}
