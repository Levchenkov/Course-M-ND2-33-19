namespace ClassLibrary
{
    public static class ExtensionBookService
    {

        public static void Add(this BookRepository books, Book new_book)
        {
            books.Data.Add(new_book);
        }

        public static void Change(this BookRepository books, int index, Book new_book)
        {
            books.Data[index] = new_book;
        }

        public static void Delete(this BookRepository books, int index)
        {
            books.Data.RemoveAt(index);
        }
    }
}