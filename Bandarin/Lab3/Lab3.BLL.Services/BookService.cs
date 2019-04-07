using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Lab3.BLL.Contracts;
using System.Text;
using System.Threading.Tasks;
using Lab3.BLL.Contracts.ViewModels;
using Lab3.DAL.Contracts;
using Lab3.DAL.Contracts.Entities;

namespace Lab3.BLL.Services
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

        public void Save(BookViewModel viewModel)
        {

            using (var transaction = unitOfWork.BeginTransaction())
            {
                try
                {
                    Book book = unitOfWork.Get<Book>(viewModel.Id);

                    if (book.LongVersion != viewModel.LongVersion)
                    {
                        throw new Exception();
                    }

                    Mapper.Map(viewModel, book);

                    unitOfWork.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }


        }

        public void Add(BookViewModel viewModel)
        {
           
            Book book =  Mapper.Map<Book>(viewModel);

            unitOfWork.Add<Book>(book);
            unitOfWork.SaveChanges();

        }
        public void Remove (BookViewModel viewModel)
        {
            Book book = unitOfWork.Get<Book>(viewModel.Id);

            
            unitOfWork.Remove<Book>(book.Id);
            unitOfWork.SaveChanges();

        }
    }
}
