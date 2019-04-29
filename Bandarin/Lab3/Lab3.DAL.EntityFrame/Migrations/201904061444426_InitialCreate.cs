namespace Lab3.DAL.EntityFrame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        Author = c.String(),
                        Created = c.DateTime(nullable: false),
                        IsPaper = c.Boolean(nullable: false),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        LongVersion = c.Long(nullable: false),
                        Delivery_Id = c.Int(nullable: false),
                        Genre_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeliveryTypes", t => t.Delivery_Id, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .Index(t => t.Delivery_Id)
                .Index(t => t.Genre_Id);
            
            CreateTable(
                "dbo.DeliveryTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookLanguages",
                c => new
                    {
                        Book_Id = c.Int(nullable: false),
                        Language_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_Id, t.Language_Id })
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.Language_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.Language_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookLanguages", "Language_Id", "dbo.Languages");
            DropForeignKey("dbo.BookLanguages", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Books", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Books", "Delivery_Id", "dbo.DeliveryTypes");
            DropIndex("dbo.BookLanguages", new[] { "Language_Id" });
            DropIndex("dbo.BookLanguages", new[] { "Book_Id" });
            DropIndex("dbo.Books", new[] { "Genre_Id" });
            DropIndex("dbo.Books", new[] { "Delivery_Id" });
            DropTable("dbo.BookLanguages");
            DropTable("dbo.Languages");
            DropTable("dbo.Genres");
            DropTable("dbo.DeliveryTypes");
            DropTable("dbo.Books");
        }
    }
}
