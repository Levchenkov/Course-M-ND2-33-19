using System.Collections.Generic;

namespace Lab2.Models
{
    public interface IFileHandler
    {
        IEnumerable<Book> Load();
        void Save(List<Book> books);
    }
}