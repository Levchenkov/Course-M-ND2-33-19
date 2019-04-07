using BookEditing.BLL.Interfaces;
using Ninject.Modules;
using BookEditing.BLL.Services;
using BookEditing.BLL.DTO;
using BookEditing.DAL.Interfaces;
using BookEditing.DAL.Repositories;

namespace BookEditing.Util
{
    //NinjectRegistrations
    public class BookModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookService<BookDTO>>().To<BookService>();
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}