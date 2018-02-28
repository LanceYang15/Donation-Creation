namespace DonationCreation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonationBoxCategories",
                c => new
                    {
                        DonationBoxCategoryId = c.Int(nullable: false, identity: true),
                        DonationBoxCateogryName = c.String(),
                    })
                .PrimaryKey(t => t.DonationBoxCategoryId);
            
            CreateTable(
                "dbo.DonationBoxes",
                c => new
                    {
                        DonationBoxId = c.Int(nullable: false, identity: true),
                        DonationBoxTitle = c.String(),
                        DonationBoxStoryDescription = c.String(),
                        DonationBoxImage = c.Binary(),
                        ApplicationUserId = c.String(maxLength: 128),
                        DonationBoxCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DonationBoxId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.DonationBoxCategories", t => t.DonationBoxCategoryId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.DonationBoxCategoryId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ItemQuantity = c.Int(nullable: true),
                        ItemDescription = c.String(),
                        DonationBoxId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.DonationBoxes", t => t.DonationBoxId, cascadeDelete: true)
                .Index(t => t.DonationBoxId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "DonationBoxId", "dbo.DonationBoxes");
            DropForeignKey("dbo.DonationBoxes", "DonationBoxCategoryId", "dbo.DonationBoxCategories");
            DropForeignKey("dbo.DonationBoxes", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Items", new[] { "DonationBoxId" });
            DropIndex("dbo.DonationBoxes", new[] { "DonationBoxCategoryId" });
            DropIndex("dbo.DonationBoxes", new[] { "ApplicationUserId" });
            DropTable("dbo.Items");
            DropTable("dbo.DonationBoxes");
            DropTable("dbo.DonationBoxCategories");
        }
    }
}
