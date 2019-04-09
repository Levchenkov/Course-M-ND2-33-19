namespace Lab4.Lib.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Created : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Created");
        }
    }
}
