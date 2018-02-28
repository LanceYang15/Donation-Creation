namespace DonationCreation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGuestUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GuestUsers", "State", c => c.String(nullable: false));
            AlterColumn("dbo.GuestUsers", "GuestUserZipCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GuestUsers", "GuestUserZipCode", c => c.Int(nullable: false));
            DropColumn("dbo.GuestUsers", "State");
        }
    }
}
