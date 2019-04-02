using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public interface IJsonWorker
    {
        IEnumerable<Book> Load(string path);
        void Save(string path, IEnumerable<Book> books);
    }
}
