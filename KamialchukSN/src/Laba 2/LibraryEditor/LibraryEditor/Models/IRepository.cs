namespace LibraryEditor.Models
{
    public interface IRepository<T>
    {
        T Get(int id);
        void Add(T entity);
        void Edit(T entity);
        void Delete(int id);
        void SaveChanges();
    }
}