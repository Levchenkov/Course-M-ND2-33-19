using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ClassLibrary1
{
    public class JsonFileHandler : IFileHandler
    {
        DataContractJsonSerializer jsonSerialize = new DataContractJsonSerializer(typeof(List<Book>));
        public string path = @"d:\!!!!!Finish\lab1+\ClassLibrary1\ClassLibrary1\bin\Debug\booksDB.json";
        public IEnumerable<Book> Load()
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                return (IEnumerable<Book>)jsonSerialize.ReadObject(fs);
            }
        }

        public void Save(List<Book> books)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                jsonSerialize.WriteObject(fs, books);
            }
        }
    }
}
