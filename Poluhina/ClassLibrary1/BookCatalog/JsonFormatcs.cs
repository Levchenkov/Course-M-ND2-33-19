using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace BookCatalog
{
    class JsonFormat
    {
        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Book>));
        public void Serialize(List<Book> listBooks)
        {
            using (FileStream fs = new FileStream(@"D:\book.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, listBooks);
            }
        }
        public List<Book> Deserialize(List<Book> listBooks)
        {
            using (FileStream fs = new FileStream(@"D:\book.json", FileMode.Open))
            {
                listBooks = (List<Book>)jsonFormatter.ReadObject(fs);
            }
            return listBooks;
        }
    }
}
