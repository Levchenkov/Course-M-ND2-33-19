namespace BookCatalog
{
    interface IRepository<T> where T : class
    {
        void Show();
        void Add(T element);
        void Change(int id, T newElement);
        void Remove(int id);
        int GetCount();
    }
}
