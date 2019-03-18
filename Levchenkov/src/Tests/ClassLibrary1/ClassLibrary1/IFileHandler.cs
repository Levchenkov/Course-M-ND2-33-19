using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public interface IFileHandler
    {
        IEnumerable<Book> Load();
        void Save(IEnumerable<Book> books);
    }
}
