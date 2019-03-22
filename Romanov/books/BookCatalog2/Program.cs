using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Newtonsoft.Json;
using static BookCatalog2.Catalog;

namespace BookCatalog2
{
    public class Program
    {

        public static Catalog ExampleInitializeOfBookCatalog()
        {
            var catalog = new Catalog();
            
            catalog.Add(new Book { Id = 1, Title = "Romanov" });
            catalog.Add(new Book { Id = 1, Title = "Ivanov" });
            catalog.Add(new Book { Id = 1, Title = "Sidorov" });
            return catalog;
        }
        static void Main(string[] args)
        {
            var catalog = JsonFile.Load();
            catalog.Add(new Book { Title = "Piece and war", Id = 6 });
            JsonFile.Save(catalog);
            ReadLine();
        }
    }
}
