using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
namespace Library
{
    public class JsonFileHandler : IFileHandler
    {
        List<Book> catalog = new List<Book>();
        private FileInfo fileinfo = new FileInfo(@"catalog.json");
        public IEnumerable<Book> Load()
        {
            if (File.Exists(@"catalog.json") && fileinfo.Length != 0)
            {
                return catalog = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(@"catalog.json"));
            }
            throw new NotImplementedException();
        }

        public void Save(List<Book> catalog)
        {
            File.WriteAllText(@"catalog.json", JsonConvert.SerializeObject(catalog));
        }
    }
}
