using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookCatalog2
{
    public class JsonFile
    {
        public static Catalog Load()
        {//read from file(deserialize)
            Catalog catalog = JsonConvert.DeserializeObject<Catalog>(File.ReadAllText(@"books.json"));
            return catalog;
        }
        public static void Save(Catalog catalog)
        {//save to file(serialize)
            using (StreamWriter file = File.CreateText(@"books.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, catalog);
            }
        }
    }
}
