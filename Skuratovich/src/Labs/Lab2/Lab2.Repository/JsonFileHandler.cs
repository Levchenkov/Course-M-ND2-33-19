using System;
using System.Collections.Generic;
using System.IO;
using Lab2.Contracts;
using Lab2.Entities.Models;
using Newtonsoft.Json;

namespace Lab2.Repository
{
    public class JsonFileHandler : IBookFileHandler
    {
        private const string path = @"Books.json";

        public IEnumerable<Book> Load()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Book>>(File.ReadAllText(path));
        }

        public void Save(List<Book> entities)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(entities));
        }
    }
}