namespace ClassLibrary1
{
    public interface IRepository<T>
    {
        T Get(int id);

        void Add(T item);
        bool Edit(T item);
        bool Remove(T item);
        void SaveChanges();
    }
}