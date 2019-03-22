using System.Collections.Generic;
using Lab2.DAL.Entities;

namespace Lab2.DAL.Interfaces
{
    public interface IFileHandler
    {
        IEnumerable<Book> Load();
        void Save(List<Book> books);
    }
}