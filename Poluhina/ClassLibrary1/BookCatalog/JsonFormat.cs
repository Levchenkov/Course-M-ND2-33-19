using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace BookCatalog
{
   public class JsonFormat:IJsonFormat
    {
        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Book>));
        public void Serialize(List<Book> listBooks)
        {
            using (FileStream fs = new FileStream(@"D:\book.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, listBooks);
            }
        }
        public List<Book> Deserialize()
        {
            using (FileStream fs = new FileStream(@"D:\book.json", FileMode.Open))
            {
                return (List<Book>)jsonFormatter.ReadObject(fs);
            }
        }
    }
}
