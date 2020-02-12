using System;
using System.Data.Entity;
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

        public IQueryable<Tag> GetAllTags()
        {
            return _dbContext.Tags;
        }

        public IQueryable<Item> GetItems(Func<Item, bool> predicate)
        {
            return _dbContext.Items.Include(x => x.ItemContent).Include(x => x.Likes).Include(x => x.Tags).Where(predicate).AsQueryable();
        }

        public IQueryable<Comment> GetAllComments()
        {
            return _dbContext.Comments;
        }

        public void Add(Item item)
        {
            var dbSet = _dbContext.Set<Item>();
            dbSet.Add(item);
        }

        public void Add(Tag tag)
        {
            var dbSet = _dbContext.Set<Tag>();
            dbSet.Add(tag);
        }

        public void Add(Category category)
        {
            var dbSet = _dbContext.Set<Category>();
            dbSet.Add(category);
        }

        public void Add(ItemContent itemContent)
        {
            var dbSet = _dbContext.Set<ItemContent>();
            dbSet.Add(itemContent);
        }

        public void Add(Comment comment)
        {
            var dbSet = _dbContext.Set<Comment>();
            dbSet.Add(comment);
        }

        public void Add(Like like)
        {
            var dbSet = _dbContext.Set<Like>();
            dbSet.Add(like);
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

        public Like GetUserLike(string userId, int itemId)
        {
            return _dbContext.Likes.FirstOrDefault(x => x.UserId == userId && x.ItemId == itemId);
        }
    }
}