using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace LibraryEditor.Models
{
    public class JsonFileHandler: IFileHandler
    {
        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Book>));

        public IEnumerable<Book> Load()
        {
            using (FileStream fs = new FileStream("LibraryBooks.json", FileMode.OpenOrCreate))
            {
                return (IEnumerable<Book>)jsonFormatter.ReadObject(fs);
            }
        }

        public void Save(List<Book> books)
        {
            using (FileStream fs = new FileStream("LibraryBooks.json", FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, books);
            }
        }
    }
}