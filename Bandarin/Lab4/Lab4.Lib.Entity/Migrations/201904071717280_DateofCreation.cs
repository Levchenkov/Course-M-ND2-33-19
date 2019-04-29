namespace Lab4.Lib.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateofCreation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "IsCreated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Books", "Created");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Created", c => c.DateTime(nullable: false));
            DropColumn("dbo.Books", "IsCreated");
        }
    }
}
