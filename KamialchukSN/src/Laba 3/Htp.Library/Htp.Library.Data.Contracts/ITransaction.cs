namespace Htp.Library.Data.Contracts
{
    public interface ITransaction
    {
        void Commit();
        void Rollback();
    }
}