namespace DonationCreation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DonationBoxCategories", "DonationBoxCateogryName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DonationBoxCategories", "DonationBoxCateogryName", c => c.String());
        }
    }
}
