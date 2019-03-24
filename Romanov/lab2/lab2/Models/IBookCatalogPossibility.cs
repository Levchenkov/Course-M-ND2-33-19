using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Models
{
    interface IBookCatalogPossibility<T> where  T: class
    {
        int Add(Book index);
        int Del(int index);

    }
}
