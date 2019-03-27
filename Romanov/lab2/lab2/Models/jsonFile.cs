using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;

namespace lab2.Models
{
    interface IJSonFile<T> where T: class
    {
        T Load();
        void Save(T catalog);
    }

    public class JsonFile : IJSonFile<Catalog>
    {
        public string Path { get; set; } = HttpContext.Current.Server.MapPath("~/App_Data/book.json");
     
        public Catalog Load()
        {
            Catalog catalog = JsonConvert.DeserializeObject<Catalog>(File.ReadAllText(Path));
            return catalog;
        }

        public void Save(Catalog catalog)
        {
            using (StreamWriter file = File.CreateText(Path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, catalog);
            }
        }

    }
}