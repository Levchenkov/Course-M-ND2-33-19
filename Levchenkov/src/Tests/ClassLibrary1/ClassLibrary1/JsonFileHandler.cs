using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace ClassLibrary1
{
    public class JsonFileHandler : IFileHandler
    {

        private DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Book>));
        private const string patch = "Books.json";


        IEnumerable<Book> IFileHandler.Load()
        {
            using (FileStream fileStream = File.Open("Books.json", FileMode.Open, FileAccess.Read))
            {
                return (IEnumerable<Book>)jsonSerializer.ReadObject(fileStream);
            }
        }

        public void Save(List<Book> books)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                jsonSerializer.WriteObject(memoryStream, books);

                using (FileStream fileStream = File.Open("Books.json", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    memoryStream.WriteTo(fileStream);
                    fileStream.Flush();
                }

            }
        }
    }
}
