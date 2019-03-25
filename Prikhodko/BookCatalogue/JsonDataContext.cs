using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace BookCatalogue
{
    public class JsonDataContext<T> : IDisposable where T : class 
    {
        private readonly string path;

        public JsonDataContext(string path)
        {
            this.path = path;
        }

        public JsonDataContext() { }

        public IEnumerable<T> LoadData()
        { 
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IList<Book>));
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                IEnumerable<T> list;
                if (fileStream.Length != 0)
                {
                    list = (IEnumerable<T>)jsonFormatter.ReadObject(fileStream);
                }
                else
                {
                    list = new List<T>();
                }
                return list;
            }
        }

        public void Save(IEnumerable<T> list)
        {
            if(list == null)
            {
                File.Delete(path);
            }
            else
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IList<Book>));
                // TODO delete file only after deleting book??? 
                File.Delete(path);
                using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fileStream, list);
                }
            }
        }

        #region IDisposable Support
        private bool isDisposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
