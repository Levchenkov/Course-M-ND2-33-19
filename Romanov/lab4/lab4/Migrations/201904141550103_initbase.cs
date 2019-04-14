namespace lab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initbase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "UpdatedByApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Books", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Books", new[] { "UpdatedByApplicationUser_Id" });
            DropColumn("dbo.Books", "CreatedByApplicationUser_Id");
            RenameColumn(table: "dbo.Books", name: "ApplicationUser_Id", newName: "CreatedByApplicationUser_Id");
            AddColumn("dbo.Books", "ApplicationUserId", c => c.Int());
            DropColumn("dbo.Books", "UpdatedByApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "UpdatedByApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Books", "ApplicationUserId");
            RenameColumn(table: "dbo.Books", name: "CreatedByApplicationUser_Id", newName: "ApplicationUser_Id");
            AddColumn("dbo.Books", "CreatedByApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Books", "UpdatedByApplicationUser_Id");
            CreateIndex("dbo.Books", "ApplicationUser_Id");
            AddForeignKey("dbo.Books", "UpdatedByApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
