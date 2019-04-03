using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    interface IRepositoryService
    {
        void AddBook(Book book);
        void DelBook(int id);
        Book GetBookById(int id);
        int GetBookId(Book book);
    }
}
