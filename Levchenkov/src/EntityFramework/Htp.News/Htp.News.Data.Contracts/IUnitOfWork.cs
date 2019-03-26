namespace Htp.News.Data.Contracts
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        T Get<T>(int id) where T : class;
    }
}
