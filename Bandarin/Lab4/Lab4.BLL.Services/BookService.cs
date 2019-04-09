using Lab4.BLL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4.Lib;
using AutoMapper;

namespace Lab4.BLL.Services
{
    public class BookService : IBookService

    {

        private readonly IRepository<Book> repository;
        public BookService(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        public void Add(BookViewModel viewModel)
        {
            
            Book book = Mapper.Map<Book>(viewModel);
            
            repository.Add(book);
            repository.SaveChanges();
        }

        public void Delete(BookViewModel viewModel)
        {
            
            repository.Remove(viewModel.Id);
            repository.SaveChanges();

        }

        public BookViewModel Get(int id)
        {
            Book book = repository.Get(id);

            var result = Mapper.Map<BookViewModel>(book);
            return result;
        }

        public void Update(BookViewModel viewModel)
        {
            Book book = repository.Get(viewModel.Id);
            var result = Mapper.Map(viewModel, book);
            
            repository.SaveChanges();
        }

        public void Save(BookViewModel viewModel)
        {
            

            repository.SaveChanges();
        }
    }
}
