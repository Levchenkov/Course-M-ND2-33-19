﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    interface IRepositoryService
    {
        void AddBook(Book book);
        void DeleteBook(int id);
        Book GetBook(int id);
        void Update(Book book);
    }
}
