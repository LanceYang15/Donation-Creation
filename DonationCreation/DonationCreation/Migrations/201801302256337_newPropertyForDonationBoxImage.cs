namespace DonationCreation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newPropertyForDonationBoxImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonationBoxes", "DonationBoxImageToEdit", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonationBoxes", "DonationBoxImageToEdit");
        }
    }
}
