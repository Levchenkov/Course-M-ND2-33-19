namespace Lab4.Lib.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;

    public class BookAppContext : DbContext
    {
        
        public BookAppContext()
            : base("name=BookAppContext")
        {
        }


     public  DbSet<Book> Books { get; set; }
     public DbSet<User> Users { get; set; }
     protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookTypeConfiguration());
          
        }

      
    }

    public class BookTypeConfiguration : EntityTypeConfiguration<Book>
    {
        public BookTypeConfiguration()
        {

            HasKey(x => x.Id);
            Property(x => x.Title).IsRequired();

           
        }
    }
}