using BookEditing.DAL.Entities;
using BookEditing.DAL.Interfaces;
using BookEditing.DAL.Repositories;
using BookEditing.WebAPI.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookEditing.WebAPI.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookService>().To<BookService>();
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}