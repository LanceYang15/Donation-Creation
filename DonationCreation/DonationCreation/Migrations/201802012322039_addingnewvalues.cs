namespace DonationCreation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingnewvalues : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrackingNumbers", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.TrackingNumbers", "GuestuserId", c => c.Int(nullable: false));
            CreateIndex("dbo.TrackingNumbers", "ApplicationUserId");
            CreateIndex("dbo.TrackingNumbers", "GuestuserId");
            AddForeignKey("dbo.TrackingNumbers", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TrackingNumbers", "GuestuserId", "dbo.GuestUsers", "GuestUserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrackingNumbers", "GuestuserId", "dbo.GuestUsers");
            DropForeignKey("dbo.TrackingNumbers", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.TrackingNumbers", new[] { "GuestuserId" });
            DropIndex("dbo.TrackingNumbers", new[] { "ApplicationUserId" });
            DropColumn("dbo.TrackingNumbers", "GuestuserId");
            DropColumn("dbo.TrackingNumbers", "ApplicationUserId");
        }
    }
}
