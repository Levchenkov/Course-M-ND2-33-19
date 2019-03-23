using System.Collections.Generic;

namespace LibraryEditor.Models
{
    public interface IFileHandler
    {
        IEnumerable<Book> Load();
        void Save(List<Book> books);
    }
}