namespace BookEditing.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Author = c.String(),
                        Created = c.DateTime(nullable: false),
                        Genre = c.String(),
                        IsPaper = c.Boolean(nullable: false),
                        DeliveryRequred = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookLanguages",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        LanguagetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.LanguagetId })
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguagetId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.LanguagetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookLanguages", "LanguagetId", "dbo.Languages");
            DropForeignKey("dbo.BookLanguages", "BookId", "dbo.Books");
            DropIndex("dbo.BookLanguages", new[] { "LanguagetId" });
            DropIndex("dbo.BookLanguages", new[] { "BookId" });
            DropTable("dbo.BookLanguages");
            DropTable("dbo.Languages");
            DropTable("dbo.Books");
        }
    }
}
