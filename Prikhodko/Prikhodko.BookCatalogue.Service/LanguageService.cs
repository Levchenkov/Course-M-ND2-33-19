using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Prikhodko.BookCatalogue.Service.Contracts.Interfaces;
using Prikhodko.BookCatalogue.Service.Contracts.Models;
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

        public IEnumerable<LanguageViewModel> GetAll()
        {
            var languages = repository.GetAll();
            var result = new List<LanguageViewModel>();
            foreach (var language in languages)
            {
                result.Add(Mapper.Map<LanguageViewModel>(language));
            }
            return result;
        }

        public LanguageViewModel Get(int id)
        {
            var language = repository.Get(id);
            var result = Mapper.Map<LanguageViewModel>(language);
            return result;
        }

        public IEnumerable<string> GetAllCodes()
        {
            var result = GetAll().Select(x => x.Code);
            return result;
        }

        public void Add(LanguageViewModel item)
        {
            if (item == null)
            {
                return;
            }
            else
            {
                Language language = Mapper.Map<Language>(item);
                repository.Add(language);
                unitOfWork.SaveChanges();
            }
        }

        public void Update(LanguageViewModel item)
        {
            if (item == null)
            {
                return;
            }
            else
            {
                Language language = Mapper.Map<Language>(item);
                repository.Update(language);
                unitOfWork.SaveChanges();
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
                repository.Remove(id);
                unitOfWork.SaveChanges();
            }
        }

    }
}
