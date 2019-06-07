﻿using System.Data.Entity;
using System.Linq;
using Http.News.Data.Contracts;
using Http.News.Data.Contracts.Entities;

namespace Http.News.Data.EntityFramework
{
    public class NewsRepository : INewsRepository
    {
        private readonly NewsDbContext _dbContext;

        public NewsRepository(NewsDbContext dbContext)
        {
            //Guard.ArgumentNotNull(dbContext, "DbContext");

            _dbContext = (NewsDbContext) dbContext;
        }

        public IQueryable<Category> GetAllCategories()
        {
            return _dbContext.Categories;
        }

        public IQueryable<Item> GetAllItems()
        {
            return _dbContext.Items;
        }

        public void Add(Item item)
        {
            var dbSet = _dbContext.Set<Item>();
            dbSet.Add(item);
        }

        public void Add(ItemContent itemContent)
        {
            var dbSet = _dbContext.Set<ItemContent>();
            dbSet.Add(itemContent);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public ITransaction BeginTransaction()
        {
            var transaction = new Transaction(_dbContext.Database.BeginTransaction());
            return transaction;
        }
    }
}