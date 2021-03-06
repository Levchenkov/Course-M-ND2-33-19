﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prikhodko.BookCatalogue.Data.Contracts.Models;
using Prikhodko.BookCatalogue.Service.Contracts.Models;

namespace Prikhodko.BookCatalogue.Service.Contracts.Interfaces
{
    public interface ILanguageService : IService<LanguageViewModel>
    {
        IEnumerable<string> GetAllCodes();
    }
}
