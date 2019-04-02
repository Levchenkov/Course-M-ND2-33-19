namespace Htp.Books.Common.Contracts
{
    public interface IHistoryLogHandler<TEntity>
    {
        TEntity Deserialize(string jsonString);
        string Serialize(TEntity entity);
    }
}
