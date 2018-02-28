namespace DonationCreation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednewproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonationBoxes", "DonationBoxCreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonationBoxes", "DonationBoxCreatedDate");
        }
    }
}
