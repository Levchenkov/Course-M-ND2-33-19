using System;
using System.Collections.Generic;

namespace BookCatalog
{
    public interface IFileHandler
    {
        IEnumerable<Book> Load();
        void Save(List<Book> books);
    }
}
