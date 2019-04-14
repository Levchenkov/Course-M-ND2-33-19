namespace lab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editprop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Books", "ApplicationUser_Id");
            AddForeignKey("dbo.Books", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Books", "CreatedById");
            DropColumn("dbo.Books", "UpdatedById");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "UpdatedById", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "CreatedById", c => c.Int(nullable: false));
            DropForeignKey("dbo.Books", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Books", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Books", "ApplicationUser_Id");
        }
    }
}
