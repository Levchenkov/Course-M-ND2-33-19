using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Htp.BooksAPI.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Htp.BooksAPI.Data.EntityFramework
{
    //public class UnitOfWork : IUnitOfWork
    //{
    //    private readonly ApplicationDbContext dbContext;
    //    private bool disposed = false;
    //    private Dictionary<Type, object> repositories;

    //    public ApplicationDbContext DbContext => dbContext;

    //    public UnitOfWork(ApplicationDbContext dbContext)
    //    {
    //        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    //    }

    //    public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class
    //    {
    //            if (repositories == null)
    //            {
    //                repositories = new Dictionary<Type, object>();
    //            }

    //            // what's the best way to support custom reposity?
    //            if (hasCustomRepository)
    //            {
    //                var customRepo = dbContext.GetService<IRepository<TEntity>>();
    //                if (customRepo != null)
    //                {
    //                    return customRepo;
    //                }
    //            }

    //            var type = typeof(TEntity);
    //            if (!repositories.ContainsKey(type))
    //            {
    //                repositories[type] = new Repository<TEntity>(dbContext);
    //            }

    //            return (IRepository<TEntity>)repositories[type];
    //    }




    //    public void Dispose()
    //    {
    //        Dispose(true);

    //        GC.SuppressFinalize(this);
    //    }

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!disposed)
    //        {
    //            if (disposing)
    //            {
    //                // clear repositories
    //                if (repositories != null)
    //                {
    //                    repositories.Clear();
    //                }

    //                // dispose the db context.
    //                dbContext.Dispose();
    //            }
    //        }

    //        disposed = true;
    //    }
    //}
}


//private readonly ApplicationDbContext dbContext;

//private IBookRepository bookRepository;

//private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

//public Dictionary<Type, object> Repositories
//{
//    get { return _repositories; }
//    set { Repositories = value; }
//}

//public UnitOfWork(ApplicationDbContext dbContext)
//{
//    this.dbContext = dbContext;
//}

//public IBookRepository BookRepository
//{
//    get
//    {
//        if (bookRepository == null)
//        {
//            bookRepository = new BookRepository(dbContext);
//        }

//        return bookRepository;
//    }
//}

//public IRepository<T> Repository<T>() where T : class
//{
//    if (Repositories.Keys.Contains(typeof(T)))
//    {
//        return Repositories[typeof(T)] as IRepository<T>;
//    }

//    IRepository<T> repository = new Repository<T>(dbContext);
//    Repositories.Add(typeof(T), repository);
//    return repository;
//}



////private readonly IComponentContext componentContext;

////public UnitOfWork(ApplicationDbContext dbContext, IComponentContext componentContext)
////{
////    this.dbContext = dbContext;
////    this.componentContext = componentContext;
////}

////private IRepository<TKey, TEntity> GetRepository<TKey, TEntity>()
////{
////    var repository = componentContext.Resolve<IRepository<TKey, TEntity>>();
////    return repository;
////}

////public IEnumerable<TEntity> GetAll<TKey, TEntity>()
////{
////    var repository = GetRepository<TKey, TEntity>();
////    var result = repository.GetAll();
////    return result;
////}

////public IEnumerable<TEntity> FindByCondition<TKey, TEntity>(Expression<Func<TEntity, bool>> expression)
////{
////    var repository = GetRepository<TKey, TEntity>();
////    var result = repository.FindByCondition(expression);
////    return result;
////}

////public TEntity Get<TKey, TEntity>(TKey id)
////{
////    var repository = GetRepository<TKey, TEntity>();
////    var result = repository.Get(id);
////    return result;
////}

////public void Add<TKey, TEntity>(TEntity entity)
////{
////    var repository = GetRepository<TKey, TEntity>();
////    repository.Add(entity);
////}

////public void Update<TKey, TEntity>(TEntity entity)
////{
////    var repository = GetRepository<TKey, TEntity>();
////    repository.Update(entity);
////}

////public void Delete<TKey, TEntity>(TEntity entity)
////{
////    var repository = GetRepository<TKey, TEntity>();
////    repository.Delete(entity);
////}

//public void SaveChanges()
//{
//    dbContext.SaveChanges();
//}

//public async Task<int> SaveChangesAsync()
//{
//    return await dbContext.SaveChangesAsync();
//}

//public ITransaction BeginTransaction()
//{
//    var transaction = new Transaction(dbContext.Database.BeginTransaction());
//    return transaction;
//}
