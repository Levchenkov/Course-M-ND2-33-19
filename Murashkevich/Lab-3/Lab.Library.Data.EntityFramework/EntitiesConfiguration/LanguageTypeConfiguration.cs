using System.Data.Entity.ModelConfiguration;
using Lab.Library.Data.Contracts.Entities;

namespace Lab.Library.Data.EntityFramework.EntitiesConfiguration
{
    public class LanguageTypeConfiguration : EntityTypeConfiguration<Language>
    {
        public LanguageTypeConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.LanguageNamEnum).IsRequired();
        }
    }
}
