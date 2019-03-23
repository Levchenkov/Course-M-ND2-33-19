using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace LibraryEditor.Models
{
    public class JsonFileHandler : IFileHandler
    {
        private static readonly string PathToTheJsonFile = AppDomain.CurrentDomain.GetData("DataDirectory") + @"\LibraryBooks.json";

        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Book>));

        public IEnumerable<Book> Load()
        {
            using (FileStream fs = new FileStream(PathToTheJsonFile, FileMode.OpenOrCreate))
            {
                return (IEnumerable<Book>)jsonFormatter.ReadObject(fs);
            }
        }

        public void Save(List<Book> books)
        {
            using (FileStream fs = new FileStream(PathToTheJsonFile, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, books);
            }
        }
    }
}