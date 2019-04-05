﻿namespace Http.BooksLibrary.Data.Contracts
{
    public interface IUnitOfWork
    {
        T Get<T>(int id) where T : class;
        void Add<T>(T entity) where T : class;
        void Delete<T>(int id) where T : class;
        void Change<T>(T entity) where T : class;
        void SaveChanges();
        ITransaction BeginTransaction();
    }
}