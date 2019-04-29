using System.Collections.Generic;

namespace BookCatalog
{
    public interface IJsonFormat
    {
        void Serialize(List<Book> listBooks);
        List<Book> Deserialize();
    }
}
