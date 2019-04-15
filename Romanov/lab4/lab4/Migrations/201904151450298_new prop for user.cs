namespace lab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newpropforuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "UpdatedBy", c => c.String());
            AddColumn("dbo.Books", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            CreateIndex("dbo.Books", "ApplicationUser_Id1");
            AddForeignKey("dbo.Books", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.Books", new[] { "ApplicationUser_Id1" });
            DropColumn("dbo.Books", "ApplicationUser_Id1");
            DropColumn("dbo.Books", "UpdatedBy");
        }
    }
}
