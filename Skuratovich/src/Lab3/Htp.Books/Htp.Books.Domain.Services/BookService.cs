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

        public void Add(BookViewModel bookViewModel)
        {
            var result = mapper.Map<Book>(bookViewModel);

            var genre = unitOfWork.Repository<int, Genre>().Get(result.Genre.Id);
            result.Genre = genre;
            unitOfWork.Repository<int, Book>().Add(result);
            unitOfWork.Repository<int, Book>().Save();
        }

        public void Edit(BookViewModel bookViewModel)
        {
            ////Book book = unitOfWork.Repository<int, Book>().Get(bookViewModel.Id);

            //// TODO: compare RowTimestamp

            //var result = mapper.Map<Book>(bookViewModel);
            ////var genre = unitOfWork.Repository<int, Genre>().Get(bookViewModel.GenreId);
            ////result.Genre = genre;
            //unitOfWork.Repository<int, Book>().Update(result);
            //unitOfWork.Repository<int, Book>().Save();
            //WriteLog(result);

            // 2
            var result = mapper.Map<Book>(bookViewModel);
            unitOfWork.Repository<int, Book>().Update(result);
            unitOfWork.Repository<int, Book>().Save();

            // 3
            //Book book = unitOfWork.Repository<int, Book>().Get(bookViewModel.Id);
            //book = mapper.Map<Book>(bookViewModel);
            //unitOfWork.Repository<int, Book>().Update(book);
            //unitOfWork.Repository<int, Book>().Save();
        }

        public BookViewModel Get(int id)
        {
            Book book = unitOfWork.Repository<int, Book>().Get(id);
            Genre genre = unitOfWork.Repository<int, Genre>().Get(book.GenreId);
            var result = mapper.Map<BookViewModel>(book);
            result.GenreTitle = genre.Title;

            IEnumerable<HistoryLog> historyLogs = unitOfWork.Repository<int, HistoryLog>().FindByCondition(x => x.EntityId == book.Id.ToString() && x.EntityType == book.GetType().ToString());

            var count = 0;
            foreach(var historyLog in historyLogs)
            {
                count++; 
            }

            result.HistoryLog = $"{count} version(s)";

            return result;
        }

        public IEnumerable<BookViewModel> GetAll()
        {
            IEnumerable<Book> books = unitOfWork.Repository<int, Book>().GetAll();

            var result = mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(books);
    
            return result;
        }

        public IEnumerable<HistoryLogViewModel> GetHistoryLogs(int id)
        {
            IEnumerable<HistoryLog> historyLogs = unitOfWork.Repository<int, HistoryLog>().FindByCondition(x => x.EntityId == id.ToString() && x.EntityType == typeof(Book).ToString());

            var result = mapper.Map<IEnumerable<HistoryLog>, IEnumerable<HistoryLogViewModel>>(historyLogs);

            foreach (var historyLog in result)
            {
                historyLog.CurrentBook = mapper.Map<Book, BookViewModel>(historyLogHandler.Deserialize(historyLog.Actually));
                historyLog.OriginBook = mapper.Map<Book, BookViewModel>(historyLogHandler.Deserialize(historyLog.Origin));
            }

            return result;
        }

        public List<SelectListItem> GetGenres()
        {
            var genres = new List<SelectListItem>();
            foreach (var ganre in unitOfWork.Repository<int, Genre>().GetAll())
            {
                genres.Add(new SelectListItem() { Value = ganre.Id.ToString(), Text = ganre.Title });

            }
            return genres;
        }

        public void Test(BookViewModel bookViewModel)
        {
            // Work, but don't track (
            //var result = mapper.Map<Book>(bookViewModel);
            //unitOfWork.Repository<int, Book>().Update(result);
            //unitOfWork.Repository<int, Book>().Save();

            Book book = unitOfWork.Repository<int, Book>().Get(bookViewModel.Id);
            book = mapper.Map<Book>(bookViewModel);
            unitOfWork.Repository<int, Book>().Test(book);
            //unitOfWork.Repository<int, Book>().Save();


            ////Book book = unitOfWork.Repository<int, Book>().Get(bookViewModel.Id);

            //// TODO: compare RowTimestamp

            //var result = mapper.Map<Book>(bookViewModel);
            ////var genre = unitOfWork.Repository<int, Genre>().Get(bookViewModel.GenreId);
            ////result.Genre = genre;
            //unitOfWork.Repository<int, Book>().Update(result);
            //unitOfWork.Repository<int, Book>().Save();
            //WriteLog(result);


            // 3
            //Book book = unitOfWork.Repository<int, Book>().Get(bookViewModel.Id);
            //book = mapper.Map<Book>(bookViewModel);
            //unitOfWork.Repository<int, Book>().Update(book);
            //unitOfWork.Repository<int, Book>().Save();
        }
    }
}
