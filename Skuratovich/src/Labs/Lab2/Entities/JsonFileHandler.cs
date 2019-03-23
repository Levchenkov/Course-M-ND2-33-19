using System;
using System.Collections.Generic;

namespace Lab2.Entities
{
    public class JsonFileHandler<T> : IFileHandler<T> where T : class
    {
        public IEnumerable<T> Load()
        {
            throw new NotImplementedException();
        }

        public void Save(List<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}


//private DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Book>));
//private const string path = "Books.json";


//IEnumerable<Book> IFileHandler.Load()
//{
//    using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
//    {
//        return (IEnumerable<Book>)jsonSerializer.ReadObject(fileStream);
//    }
//}


//public void Save(List<Book> books)
//{
//    using (FileStream fileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write))
//    {
//        jsonSerializer.WriteObject(fileStream, books);
//    }
//}
