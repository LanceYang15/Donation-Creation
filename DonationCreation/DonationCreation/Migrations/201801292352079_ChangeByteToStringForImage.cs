namespace DonationCreation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeByteToStringForImage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DonationBoxes", "DonationBoxImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DonationBoxes", "DonationBoxImage", c => c.Binary());
        }
    }
}
