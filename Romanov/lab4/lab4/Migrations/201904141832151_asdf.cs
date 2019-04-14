namespace lab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdf : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Books", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.Books", "CreatedById", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "UpdatedById", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Books", "UpdatedById");
            DropColumn("dbo.Books", "CreatedById");
            CreateIndex("dbo.Books", "ApplicationUser_Id");
            AddForeignKey("dbo.Books", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
