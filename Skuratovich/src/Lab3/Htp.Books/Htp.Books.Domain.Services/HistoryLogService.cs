using System.Collections.Generic;
using AutoMapper;
using Htp.Books.Data.Contracts;
using Htp.Books.Data.Contracts.Entities;
using Htp.Books.Domain.Contracts;
using Htp.Books.Domain.Contracts.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Htp.Books.Domain.Services
{
    public class HistoryLogService : IHistoryLogService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;


        public HistoryLogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public HistoryLogViewModel Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<HistoryLogViewModel> GetAll()
        {
            IEnumerable<HistoryLog> historyLogs = unitOfWork.GetAll<int, HistoryLog>();

            var result = mapper.Map<IEnumerable<HistoryLog>, IEnumerable<HistoryLogViewModel>>(historyLogs);
         
            return result;
        }

        //public void Add(BookViewModel bookViewModel)
        //{
        //    var result = mapper.Map<Book>(bookViewModel);

        //    var genre = unitOfWork.Repository<int, Genre>().Get(result.Genre.Id);
        //    result.Genre = genre;
        //    unitOfWork.Repository<int, Book>().Add(result);
        //    unitOfWork.Repository<int, Book>().Save();
        //}

        //public void Edit(BookViewModel bookViewModel)
        //{
        //    //Book book = unitOfWork.Repository<int, Book>().Get(bookViewModel.Id);

        //    // TODO: compare RowTimestamp

        //    var result = mapper.Map<Book>(bookViewModel);
        //    //var genre = unitOfWork.Repository<int, Genre>().Get(bookViewModel.GenreId);
        //    //result.Genre = genre;
        //    unitOfWork.Repository<int, Book>().Update(result);
        //    unitOfWork.Repository<int, Book>().Save();
        //}

        //public BookViewModel Get(int id)
        //{
        //    Book book = unitOfWork.Repository<int, Book>().Get(id);
        //    Genre genre = unitOfWork.Repository<int, Genre>().Get(book.GenreId);
        //    var result = mapper.Map<BookViewModel>(book);
        //    result.GenreTitle = genre.Title;
        //    return result;
        //}

        //public IEnumerable<BookViewModel> GetAll()
        //{
        //    IEnumerable<Book> books = unitOfWork.Repository<int, Book>().GetAll();

        //    var result = mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(books);
        //    //var result = Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(books);

        //    return result;
        //}

        //public List<SelectListItem> GetGenres()
        //{
        //    var genres = new List<SelectListItem>();
        //    foreach (var ganre in unitOfWork.Repository<int, Genre>().GetAll())
        //    {
        //        genres.Add(new SelectListItem() { Value = ganre.Id.ToString(), Text = ganre.Title });

        //    }
        //    return genres;
        //}

    }
}
