namespace DonationCreation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateNewTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PostOfficeBoxId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostOfficeBoxes", t => t.PostOfficeBoxId, cascadeDelete: true)
                .Index(t => t.PostOfficeBoxId);
            
            CreateTable(
                "dbo.PostOfficeBoxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        POBox = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "ProfileId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "ProfileId");
            AddForeignKey("dbo.AspNetUsers", "ProfileId", "dbo.Profiles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Profiles", "PostOfficeBoxId", "dbo.PostOfficeBoxes");
            DropIndex("dbo.Profiles", new[] { "PostOfficeBoxId" });
            DropIndex("dbo.AspNetUsers", new[] { "ProfileId" });
            DropColumn("dbo.AspNetUsers", "ProfileId");
            DropTable("dbo.PostOfficeBoxes");
            DropTable("dbo.Profiles");
        }
    }
}
