using System.Collections.Generic;

namespace WebBookLibrary.Models.LibraryModels
{
    public interface IFileHandler
    {
        IEnumerable<Book> Load();
        void Save(List<Book> books);
    }
}