using System;
using Htp.Books.Data.Contracts.Entities;

namespace Htp.Books.Data.Contracts
{
    public interface IBookRepository : IRepository<int, Book>
    {
    }
}
