namespace BookLibrary
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> repository;

        public BookService(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        public Book Get(int id)
        {
            return repository.Get(id);
        }

    }
}