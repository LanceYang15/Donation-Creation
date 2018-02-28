namespace DonationCreation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewModelPackageManger : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrackingNumbers",
                c => new
                    {
                        TrackingNumberId = c.Int(nullable: false, identity: true),
                        TrackingNumberString = c.String(),
                    })
                .PrimaryKey(t => t.TrackingNumberId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TrackingNumbers");
        }
    }
}
