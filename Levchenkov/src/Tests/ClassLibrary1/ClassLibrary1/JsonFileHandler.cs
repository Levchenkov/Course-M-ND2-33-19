using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public class JsonFileHandler : IFileHandler
    {
        public IEnumerable<Book> Load()
        {
            throw new NotImplementedException();
        }

        public void Save(IEnumerable<Book> books)
        {
            throw new NotImplementedException();
        }
    }
}
