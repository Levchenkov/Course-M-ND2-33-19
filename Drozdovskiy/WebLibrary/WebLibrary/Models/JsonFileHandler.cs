using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
namespace WebLibrary.Models
{
    public class JsonFileHandler : IFileHandler
    {
        List<Book> catalog = new List<Book>();
        public IEnumerable<Book> Load()
        {
            return catalog = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(AppDomain.CurrentDomain.GetData("DataDirectory")+@"\catalog.json"));

        }

        public void Save(List<Book> catalog)
        {
            File.WriteAllText(AppDomain.CurrentDomain.GetData("DataDirectory") + @"\catalog.json", JsonConvert.SerializeObject(catalog));
        }
    }
}
