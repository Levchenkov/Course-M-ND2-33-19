using System.Collections.Generic;

namespace WebLibrary.Models
{
    public interface IFileHandler
    {
        IEnumerable<Book> Load();
        void Save(List<Book> books);
    }
}