namespace Lab4.Lib.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userNameAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Books", "UpdatedBy_Id", "dbo.Users");
            DropIndex("dbo.Books", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Books", new[] { "UpdatedBy_Id" });
            AddColumn("dbo.Books", "CreatedBy", c => c.String());
            AddColumn("dbo.Books", "UpdatedBy", c => c.String());
            DropColumn("dbo.Books", "CreatedBy_Id");
            DropColumn("dbo.Books", "UpdatedBy_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "UpdatedBy_Id", c => c.Int());
            AddColumn("dbo.Books", "CreatedBy_Id", c => c.Int());
            DropColumn("dbo.Books", "UpdatedBy");
            DropColumn("dbo.Books", "CreatedBy");
            CreateIndex("dbo.Books", "UpdatedBy_Id");
            CreateIndex("dbo.Books", "CreatedBy_Id");
            AddForeignKey("dbo.Books", "UpdatedBy_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Books", "CreatedBy_Id", "dbo.Users", "Id");
        }
    }
}
