namespace DonationCreation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewPropertyItemDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonationBoxes", "DonationBoxItemDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonationBoxes", "DonationBoxItemDescription");
        }
    }
}
