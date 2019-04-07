using BookEditing.BLL.Interfaces;
using Ninject.Modules;
using BookEditing.BLL.Services;
using BookEditing.BLL.DTO;

namespace BookEditing.Util
{
    public class BookModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookService<BookDTO>>().To<BookService>();
        }
    }
}