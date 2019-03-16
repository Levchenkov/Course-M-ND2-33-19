using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace BookLibraryCRUD
{
    public class LibraryDBInitializator : LibraryContext
    {
        private readonly DataContractJsonSerializer jsonFormatter =
            new DataContractJsonSerializer(typeof(List<Book>));

        private readonly string path = @"../../../App_Data/library.json";

        public LibraryDBInitializator()
        {
            using (var fs =
                new FileStream(path, FileMode.OpenOrCreate))
            {
                if (fs.Length == 0)
                {
                    Books = new List<Book>
                    {
                        new Book {Id = 1, Title = "Title1"},
                        new Book {Id = 2, Title = "Title2"},
                        new Book {Id = 3, Title = "Title3"}
                    };
                    jsonFormatter.WriteObject(fs, Books);
                }
                else
                {
                    Books = jsonFormatter.ReadObject(fs) as List<Book>;
                }
            }
        }

        public void SetDbToJson()
        {
            using (var fs =
                new FileStream(@"../../../App_Data/library.json", FileMode.Truncate))
            {
                jsonFormatter.WriteObject(fs, Books);
            }
        }
    }
}