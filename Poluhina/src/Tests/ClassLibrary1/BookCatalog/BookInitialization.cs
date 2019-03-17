using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace BookCatalog
{
    public class BookInitialization
    {
        public virtual List<Book> listBooks { get; set; }

        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Book>));
        public void InitialInitialization()
        {
            if (File.Exists(@"D:\book.json"))
            {
                JsonDeserializer();
            }
            else
            {
                listBooks = new List<Book>
            {
                new Book{ Author= "Michael Bulgakov", Name="The Master and Margarita", Year=1929, Genre="novel" },
                new Book{ Author= "Ivan Turgenev", Name="Asya", Year=1858, Genre="novel"},
                new Book{ Author= "Nikolai Gogol", Name="Dead Souls", Year=1842, Genre="novel"},
                new Book{ Author= "Alexey Tolstoy ", Name="Going around ", Year=1922, Genre="novel"}
            };
                JsonSerializer();
            }
        }
        public void JsonSerializer()
        {
            using (FileStream fs = new FileStream(@"D:\book.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, listBooks);
            }
        }
        public void JsonDeserializer()
        {
            using (FileStream fs = new FileStream(@"D:\book.json", FileMode.Open))
            {
                listBooks = (List<Book>)jsonFormatter.ReadObject(fs);
            }
        }
    }
}
