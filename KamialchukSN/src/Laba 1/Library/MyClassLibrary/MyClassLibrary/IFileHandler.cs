using System.Collections.Generic;

namespace MyClassLibrary
{
    public interface IFileHandler
    {
        IEnumerable<Book> Load();
        void Save(List<Book> books);
    }
}
