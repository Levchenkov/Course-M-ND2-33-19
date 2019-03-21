using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        

        public Book(int id, string title)
        {
            ID = id;
            Title = title;            
        }
        public Book()
        {

        }
    }
}
