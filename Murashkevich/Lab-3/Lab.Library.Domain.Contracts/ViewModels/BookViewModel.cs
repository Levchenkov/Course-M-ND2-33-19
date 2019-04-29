using System;
using System.Collections.Generic;
using System.Linq;
using Lab.Library.Data.Contracts.Entities;

namespace Lab.Library.Domain.Contracts.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }

        private Genre _genre;
        public Genre Genre
        {
            get
            {
                if (SelectedGenre != null)
                {
                    _genre = new Genre()
                    {
                        GenreNamEnum = (GenreEnum) SelectedGenre.First()
                    };
                }
                return _genre;
            }
            set => _genre = value;
        }

        public bool IsPaper { get; set; }

        private ICollection<Language> _languages;
        public ICollection<Language> Languages
        {
            get
            {
                if (SelectedLanguages != null)
                {
                    _languages = new List<Language>();
                    foreach (var language in SelectedLanguages)
                    {
                        _languages.Add(new Language() {LanguageNamEnum = (LanguageEnum) language});
                    }
                }
                return _languages;
            }
            set => _languages = value;
        }

        public bool DeliveryRequired { get; set; }

        public int?[] SelectedGenre { get; set; }
        public int?[] SelectedLanguages { get; set; }

        private string _stringLanguage;
        public string StringLanguage
        {
            get
            {
                _stringLanguage = "";
                foreach (var language in Languages)
                {
                    _stringLanguage += language.LanguageNamEnum.ToString() + ", ";
                }

                return _stringLanguage.Remove(_stringLanguage.Length - 2, 2);
            }
        }
    }
}
