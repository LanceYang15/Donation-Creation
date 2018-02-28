namespace DonationCreation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profiles", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Profiles", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.PostOfficeBoxes", "POBox", c => c.String(nullable: false));
            AlterColumn("dbo.PostOfficeBoxes", "City", c => c.String(nullable: false));
            AlterColumn("dbo.PostOfficeBoxes", "State", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PostOfficeBoxes", "State", c => c.String());
            AlterColumn("dbo.PostOfficeBoxes", "City", c => c.String());
            AlterColumn("dbo.PostOfficeBoxes", "POBox", c => c.String());
            AlterColumn("dbo.Profiles", "LastName", c => c.String());
            AlterColumn("dbo.Profiles", "FirstName", c => c.String());
        }
    }
}
