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
        static void Main(string[] args)
        {
            Catalog myCatalog = JsonFile.Load();
            
            //Catalog.Delete(myCatalog, 9);
            Catalog.Edit(myCatalog, 1, new Book() { Title = "I use Edit method", Id = 100500 });
            JsonFile.Save(myCatalog);
            Catalog.ShowAllBooks(myCatalog);

            ReadLine();
        }
    }
}
