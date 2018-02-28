namespace DonationCreation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removetables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "PostOfficeBoxId", "dbo.PostOfficeBoxes");
            DropIndex("dbo.Profiles", new[] { "PostOfficeBoxId" });
            DropTable("dbo.PostOfficeBoxes");
            DropTable("dbo.Profiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PostOfficeBoxId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostOfficeBoxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        POBox = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Profiles", "PostOfficeBoxId");
            AddForeignKey("dbo.Profiles", "PostOfficeBoxId", "dbo.PostOfficeBoxes", "Id", cascadeDelete: true);
        }
    }
}
