using BookEditing.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEditing.WebAPI.Services
{
    public interface IBookService
    {
        IEnumerable <BookApiModel> GetList();
        void Add(BookApiModel item);
        void Change(BookApiModel item);
        void Remove(int id);
        BookApiModel Get(int id);
    }
}
