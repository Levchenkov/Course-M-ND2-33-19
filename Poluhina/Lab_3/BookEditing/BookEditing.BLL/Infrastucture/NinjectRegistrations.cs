using BookEditing.DAL.Repositories;
using BookEditing.DAL.Interfaces;
using Ninject.Modules;

namespace BookEditing.BLL.Infrastucture
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}