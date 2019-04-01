using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prikhodko.BookCatalogue.Data.Contracts.Interfaces;
using Prikhodko.BookCatalogue.Data.Contracts.Models;

namespace Prikhodko.BookCatalogue.Data.EF
{
    public class EFLanguageRepository : IRepository<Language>
    {
        private readonly ApplicationDbContext dbContext;

        public EFLanguageRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Language item)
        {
            throw new NotImplementedException();
        }

        public Language Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Language item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Language> GetAll()
        {
            var result = dbContext.Languages.ToList();
            return result;
        }
    }
}
