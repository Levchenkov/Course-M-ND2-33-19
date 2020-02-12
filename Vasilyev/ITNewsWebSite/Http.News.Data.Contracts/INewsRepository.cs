using System;
using System.Linq;
using Http.News.Data.Contracts.Entities;

namespace Http.News.Data.Contracts
{
    public interface INewsRepository
    {
        IQueryable<Category> GetAllCategories();

        IQueryable<Item> GetAllItems();

        IQueryable<Comment> GetAllComments();

        IQueryable<Tag> GetAllTags();

        IQueryable<Item> GetItems(Func<Item, bool> predicate);

        void Add(Item item);

        void Add(Category category);

        void Add(ItemContent itemContent);

        void Add(Comment comment);

        void Add(Like like);

        void Add(Tag tag);

        void Save();

        ITransaction BeginTransaction();

        Like GetUserLike(string userId, int itemId);
    }
}