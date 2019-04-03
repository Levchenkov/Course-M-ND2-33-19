namespace Htp.News.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVersionForPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Version");
        }
    }
}
