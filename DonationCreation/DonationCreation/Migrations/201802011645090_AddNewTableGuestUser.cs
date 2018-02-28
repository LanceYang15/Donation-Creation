namespace DonationCreation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTableGuestUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GuestUsers",
                c => new
                    {
                        GuestUserId = c.Int(nullable: false, identity: true),
                        GuestUserEmail = c.String(nullable: false),
                        GuestUserFirstName = c.String(nullable: false),
                        GuestUserLastName = c.String(nullable: false),
                        GuestUserCity = c.String(nullable: false),
                        GuestUserZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GuestUserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GuestUsers");
        }
    }
}
