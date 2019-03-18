using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace ClassLibrary1
{
    public class JsonFileHandler : IFileHandler
    {

        private DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Book>));
        private const string path = "Books.json";


        IEnumerable<Book> IFileHandler.Load()
        {
            using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                return (IEnumerable<Book>)jsonSerializer.ReadObject(fileStream);
            }
        }


        public void Save(List<Book> books)
        {
            using (FileStream fileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                jsonSerializer.WriteObject(fileStream, books);
            }
        }
    }
}

