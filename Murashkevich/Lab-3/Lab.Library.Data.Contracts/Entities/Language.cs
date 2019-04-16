using System.Collections.Generic;

namespace Lab.Library.Data.Contracts.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public LanguageEnum LanguageNamEnum { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }

    public enum LanguageEnum
    {
        Russian = 1,
        English,
        German,
        Spanish,
        Chinese
    }
}
