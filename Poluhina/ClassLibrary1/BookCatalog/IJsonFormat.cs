using System;
using System.Collections.Generic;
using System.Text;

namespace BookCatalog
{
    public interface IJsonFormat
    {
        void Serialize(List<Book> listBooks);
        List<Book> Deserialize();
    }
}
