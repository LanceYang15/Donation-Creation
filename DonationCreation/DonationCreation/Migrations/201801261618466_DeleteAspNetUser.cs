namespace DonationCreation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAspNetUser : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM AspNetUsers WHERE PhoneNumber = 'Lance'");
        }
        
        public override void Down()
        {
        }
    }
}
