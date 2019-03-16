namespace BookLibraryCRUD {
    public interface IRepository<out T>
    {
        T Get(int id);
        T GetLast();
    }
}