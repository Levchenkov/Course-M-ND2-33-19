namespace lab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedprop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "UpdatedTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "UpdatedTime");
        }
    }
}
