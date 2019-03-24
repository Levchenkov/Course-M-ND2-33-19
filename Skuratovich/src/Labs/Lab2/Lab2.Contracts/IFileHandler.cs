using System.Collections.Generic;

namespace Lab2.Contracts
{
    public interface IFileHandler<T>
    {
        IEnumerable<T> Load();
        void Save(List<T> entities);
    }
}
