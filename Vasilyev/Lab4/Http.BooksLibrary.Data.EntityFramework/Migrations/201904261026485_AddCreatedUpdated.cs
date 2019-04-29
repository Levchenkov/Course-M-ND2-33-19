namespace Http.BooksLibrary.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Created", c => c.DateTime());
            AlterColumn("dbo.Books", "Updated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Updated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Books", "Created", c => c.DateTime(nullable: false));
        }
    }
}
