namespace DonationCreation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedformat : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.AspNetUsers", new[] { "ProfileId" });
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "PoBox", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "State", c => c.String());
            AddColumn("dbo.AspNetUsers", "zipcode", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "ProfileId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ProfileId", c => c.Int());
            DropColumn("dbo.AspNetUsers", "zipcode");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "PoBox");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            CreateIndex("dbo.AspNetUsers", "ProfileId");
            AddForeignKey("dbo.AspNetUsers", "ProfileId", "dbo.Profiles", "Id");
        }
    }
}
