namespace lab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "CreatedByApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Books", "UpdatedByApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Books", new[] { "CreatedByApplicationUser_Id" });
            DropIndex("dbo.Books", new[] { "UpdatedByApplicationUser_Id" });
            AddColumn("dbo.Books", "ApplicationUserId", c => c.Int());
            DropColumn("dbo.Books", "CreatedByApplicationUser_Id");
            DropColumn("dbo.Books", "UpdatedByApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "UpdatedByApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Books", "CreatedByApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Books", "ApplicationUserId");
            CreateIndex("dbo.Books", "UpdatedByApplicationUser_Id");
            CreateIndex("dbo.Books", "CreatedByApplicationUser_Id");
            AddForeignKey("dbo.Books", "UpdatedByApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Books", "CreatedByApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
