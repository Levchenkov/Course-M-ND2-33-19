using System.Linq;
using Http.News.Data.Contracts.Entities;

namespace Http.News.Data.Contracts
{
    public interface INewsRepository
    {
        IQueryable<Category> GetAllCategories();

        IQueryable<Item> GetAllItems();
    }
}