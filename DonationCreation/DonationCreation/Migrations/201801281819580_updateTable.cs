namespace DonationCreation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "ItemQuantity", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "ItemQuantity", c => c.Int(nullable: false));
        }
    }
}
