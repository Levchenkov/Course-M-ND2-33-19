namespace Lab2.DAL.Interfaces
{
    public interface IRepository<T>
    {
        T Get(int id);

        void Add(T item);
        bool Edit(T item);
        bool Remove(T item);

        //TODO: Check
        void SaveChanges();
    }
}