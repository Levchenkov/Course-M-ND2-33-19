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

        public void Add(BookViewModel bookViewModel)
        {
            var result = mapper.Map<Book>(bookViewModel);
            var genre = unitOfWork.Get<int, Genre>(result.GenreId);
            result.Genre = genre;

            using (var transaction = unitOfWork.BeginTransaction())
            {
                try
                {
                    unitOfWork.Add<int, Book>(result);
                    //unitOfWork.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public BookViewModel Get(int id)
        {
            Book book = unitOfWork.Get<int, Book>(id);
            Genre genre = unitOfWork.Get<int, Genre>(book.GenreId);
            book.Genre = genre;
            var result = mapper.Map<BookViewModel>(book);

            IEnumerable<HistoryLog> historyLogs = unitOfWork.FindByCondition<int, HistoryLog>(x => x.EntityId == book.Id.ToString() && x.EntityType == book.GetType().ToString());

            var count = 0;
            foreach (var historyLog in historyLogs)
            {
                count++;
            }

            result.HistoryLog = $"{count} version(s)";

            return result;
        }

        public void Edit(BookViewModel bookViewModel)
        {
            Book book = unitOfWork.Get<int, Book>(bookViewModel.Id);
            mapper.Map(bookViewModel, book);

            using (var transaction = unitOfWork.BeginTransaction())
            {
                try
                {
                    unitOfWork.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public IEnumerable<HistoryLogViewModel> GetHistoryLogs(int id)
        {
            IEnumerable<HistoryLog> historyLogs = unitOfWork.FindByCondition<int, HistoryLog>(x => x.EntityId == id.ToString() && x.EntityType == typeof(Book).ToString());

            var result = mapper.Map<IEnumerable<HistoryLogViewModel>>(historyLogs);

            foreach (var historyLog in result)
            {
                historyLog.CurrentBook = mapper.Map<Book, BookViewModel>(historyLogHandler.Deserialize(historyLog.Actually));
                historyLog.OriginBook = mapper.Map<Book, BookViewModel>(historyLogHandler.Deserialize(historyLog.Origin));
            }

            return result;
        }

        public void Delete(BookViewModel bookViewModel)
        {
            Book book = unitOfWork.Get<int, Book>(bookViewModel.Id);
            mapper.Map(bookViewModel, book);

            using (var transaction = unitOfWork.BeginTransaction())
            {
                try
                {
                    unitOfWork.Delete<int, Book>(book);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
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
    }
}
