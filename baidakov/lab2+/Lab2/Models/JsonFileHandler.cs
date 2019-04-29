using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Lab2.Models
{
    public class JsonFileHandler : IFileHandler
    {
        private static readonly string path =
        AppDomain.CurrentDomain.GetData("DataDirectory") + @"\booksDB.json";

        private readonly DataContractJsonSerializer jsonSerialize = 
        new DataContractJsonSerializer(typeof(List<Book>));

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
