using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class JsonDb : IJsonDbService
    {
        private readonly string PathToJsonDb =  HttpContext.Current.Server.MapPath("~/App_Data/books.json");

        public Repository LoadFromJsonDbFile()
        {
            using (StreamReader file = File.OpenText(PathToJsonDb))
            {
                JsonSerializer serializer = new JsonSerializer();
                Repository repository = (Repository)serializer.Deserialize(file, typeof(Repository));
                return repository;
            }
        }

        public void SaveChangesToJsonDb(Repository repository)
        {
            using (StreamWriter file = File.CreateText(PathToJsonDb))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, repository);
            }
        }
    }
}