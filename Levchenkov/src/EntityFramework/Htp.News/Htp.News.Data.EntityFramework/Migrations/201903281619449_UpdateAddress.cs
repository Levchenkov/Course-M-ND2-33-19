namespace Htp.News.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAddress : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "Address_City", newName: "Address_City");
            RenameColumn(table: "dbo.Users", name: "Address_Street", newName: "Address_Street");
            RenameColumn(table: "dbo.Users", name: "Address_Country", newName: "Address_Country");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Users", name: "Address_Country", newName: "Country");
            RenameColumn(table: "dbo.Users", name: "Address_Street", newName: "Street");
            RenameColumn(table: "dbo.Users", name: "Address_City", newName: "City");
        }
    }
}
