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

        public IEnumerable<Language> GetAll()
        {
            var result = dbContext.Languages.ToList();
            return result;
        }

        public Language Get(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            else
            {
                var result = dbContext.Languages.Find(id);
                return result;
            }
        }

        public void Add(Language item)
        {
            if (item == null)
            {
                return;
            }
            else
            {
                dbContext.Languages.Add(item);
                dbContext.SaveChanges();
            }
        }

        public void Update(Language item)
        {
            if (item == null || item.LanguageId <= 0)
            {
                return;
            }
            else
            {
                var language = Get(item.LanguageId);
                language.Name = item.Name;
                language.Code = item.Code;
                var a = dbContext.Entry(language).State;
            }
        }
        
        public void Remove(int id)
        {
            if (id <= 0)
            {
                return;
            }
            else
            {
                var result = dbContext.Languages.Find(id);
                dbContext.Languages.Remove(result);
            }
        }
    }
}
