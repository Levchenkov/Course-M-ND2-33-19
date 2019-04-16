using System.Data.Entity.ModelConfiguration;
using Lab.Library.Data.Contracts.Entities;

namespace Lab.Library.Data.EntityFramework.EntitiesConfiguration
{
    public class GenreTypeConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreTypeConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.GenreNamEnum).IsRequired();
        }
    }
}
