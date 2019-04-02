using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;

namespace Models
{
    public class JsonWorker : IJsonWorker
    {
        public IEnumerable<Book> Load(string path)
        {
            //List<Book> books = new List<Book>();
            //FileStream fs = new FileStream(path, FileMode.Open);
            //fs.Close();
            //return books;
            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<Book> books = (List<Book>)serializer.Deserialize(file, typeof(List<Book>));
                return books;
            }            
        }

        public void Save(string path, IEnumerable<Book> books)
        {
            //FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(IEnumerable<Book>));
            //ser.WriteObject(fs, books);
            //fs.Close();
            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, books);
            }
        }
    }
}
