namespace DonationCreation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedrequiredattributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DonationBoxes", "DonationBoxTitle", c => c.String(nullable: false));
            AlterColumn("dbo.DonationBoxes", "DonationBoxStoryDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DonationBoxes", "DonationBoxStoryDescription", c => c.String());
            AlterColumn("dbo.DonationBoxes", "DonationBoxTitle", c => c.String());
        }
    }
}
