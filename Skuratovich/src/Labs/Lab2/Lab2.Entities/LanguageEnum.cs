using System.ComponentModel.DataAnnotations;

namespace Lab2.Entities
{
    public enum LanguageEnum
    {
        English = 1,
        German = 2,
        [Display(Name = "Great and powerful")]
        Russian = 3
    }
}