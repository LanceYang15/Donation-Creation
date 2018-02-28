namespace DonationCreation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.AspNetUsers", new[] { "ProfileId" });
            AlterColumn("dbo.AspNetUsers", "ProfileId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "ProfileId");
            AddForeignKey("dbo.AspNetUsers", "ProfileId", "dbo.Profiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.AspNetUsers", new[] { "ProfileId" });
            AlterColumn("dbo.AspNetUsers", "ProfileId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "ProfileId");
            AddForeignKey("dbo.AspNetUsers", "ProfileId", "dbo.Profiles", "Id", cascadeDelete: true);
        }
    }
}
