namespace BookCatalog
{
    interface IElement<T> where T : class
    {
        void Show();
        void Add(T element);
        void Change(int index, T newElement);
        void Remove(int index);
        int GetCount();
    }
}
