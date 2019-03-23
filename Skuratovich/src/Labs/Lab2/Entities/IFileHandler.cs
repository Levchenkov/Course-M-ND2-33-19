using System.Collections.Generic;

namespace Lab2.Entities
{
    public interface IFileHandler<T>
    {
        IEnumerable<T> Load();
        void Save(List<T> entities);
    }
}
