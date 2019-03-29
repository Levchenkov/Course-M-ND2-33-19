namespace Htp.Books.Data.Contracts
{
    public interface IRepository<in TKey, TEntity>
    {
        TEntity Get(TKey id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Deleta(TEntity entity);
    }
}