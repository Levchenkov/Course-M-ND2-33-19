namespace Htp.Library.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.BookLanguages", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.BookLanguages", "Language_Id", "dbo.Languages");
            DropIndex("dbo.Books", new[] { "Genre_Id" });
            DropIndex("dbo.BookLanguages", new[] { "Book_Id" });
            DropIndex("dbo.BookLanguages", new[] { "Language_Id" });
            AddColumn("dbo.Books", "Genre", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "Language", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "Genre_Id");
            DropTable("dbo.Genres");
            DropTable("dbo.Languages");
            DropTable("dbo.BookLanguages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BookLanguages",
                c => new
                    {
                        Book_Id = c.Int(nullable: false),
                        Language_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_Id, t.Language_Id });
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "Genre_Id", c => c.Int());
            DropColumn("dbo.Books", "Language");
            DropColumn("dbo.Books", "Genre");
            CreateIndex("dbo.BookLanguages", "Language_Id");
            CreateIndex("dbo.BookLanguages", "Book_Id");
            CreateIndex("dbo.Books", "Genre_Id");
            AddForeignKey("dbo.BookLanguages", "Language_Id", "dbo.Languages", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BookLanguages", "Book_Id", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Books", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
