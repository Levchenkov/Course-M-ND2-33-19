using System.Collections.Generic;

namespace Library
{
    public interface IFileHandler
    {
        IEnumerable<Book> Load();
        void Save(List<Book> books);
    }
}