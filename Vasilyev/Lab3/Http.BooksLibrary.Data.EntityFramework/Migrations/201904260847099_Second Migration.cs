namespace Http.BooksLibrary.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "CreatedBy");
            DropColumn("dbo.Books", "UpdatedBy");
            DropColumn("dbo.Books", "Updated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "UpdatedBy", c => c.String());
            AddColumn("dbo.Books", "CreatedBy", c => c.String());
        }
    }
}
