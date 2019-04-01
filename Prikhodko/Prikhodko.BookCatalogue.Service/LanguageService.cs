using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prikhodko.BookCatalogue.Service.Contracts.Interfaces;
using Prikhodko.BookCatalogue.Data.Contracts.Models;
using Prikhodko.BookCatalogue.Data.Contracts.Interfaces;

namespace Prikhodko.BookCatalogue.Service
{
    public class LanguageService : ILanguageService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Language> repository;

        public LanguageService(IUnitOfWork unitOfWork, IRepository<Language> repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }

        public void Add(Language item)
        {
            throw new NotImplementedException();
        }

        public Language Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Language> GetAll()
        {
            var result = repository.GetAll();
            return result;
        }

        public IEnumerable<string> GetAllCodes()
        {
            var result = GetAll().Select(x => x.Code);
            return result;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Language item)
        {
            throw new NotImplementedException();
        }
    }
}
