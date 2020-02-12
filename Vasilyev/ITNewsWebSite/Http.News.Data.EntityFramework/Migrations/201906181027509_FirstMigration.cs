namespace Http.News.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemContentId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Rating = c.Double(nullable: false),
                        TotalRaters = c.Int(nullable: false),
                        TotalLikes = c.Int(nullable: false),
                        TotalDislikes = c.Int(nullable: false),
                        AverageRating = c.Double(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.ItemContents", t => t.ItemContentId, cascadeDelete: true)
                .Index(t => t.ItemContentId)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Author = c.String(),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ItemContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ShortDescription = c.String(),
                        Content = c.String(),
                        SmallImage = c.String(),
                        MediumImage = c.String(),
                        BigImage = c.String(),
                        NumOfView = c.Long(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        ItemId = c.Int(nullable: false),
                        IsLike = c.Boolean(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.ItemId })
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Text = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Text)
                .Index(t => t.Text, unique: true);
            
            CreateTable(
                "dbo.TagItems",
                c => new
                    {
                        Tag_Text = c.String(nullable: false, maxLength: 128),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Text, t.Item_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Text, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .Index(t => t.Tag_Text)
                .Index(t => t.Item_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.TagItems", "Tag_Text", "dbo.Tags");
            DropForeignKey("dbo.Likes", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "ItemContentId", "dbo.ItemContents");
            DropForeignKey("dbo.Comments", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "Category_Id", "dbo.Categories");
            DropIndex("dbo.TagItems", new[] { "Item_Id" });
            DropIndex("dbo.TagItems", new[] { "Tag_Text" });
            DropIndex("dbo.Tags", new[] { "Text" });
            DropIndex("dbo.Likes", new[] { "ItemId" });
            DropIndex("dbo.Comments", new[] { "ItemId" });
            DropIndex("dbo.Items", new[] { "Category_Id" });
            DropIndex("dbo.Items", new[] { "ItemContentId" });
            DropTable("dbo.TagItems");
            DropTable("dbo.Tags");
            DropTable("dbo.Likes");
            DropTable("dbo.ItemContents");
            DropTable("dbo.Comments");
            DropTable("dbo.Items");
            DropTable("dbo.Categories");
        }
    }
}
