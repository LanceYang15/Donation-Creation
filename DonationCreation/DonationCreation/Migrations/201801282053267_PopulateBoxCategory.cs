namespace DonationCreation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBoxCategory : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT DonationBoxCategories ON");
            Sql("INSERT INTO DonationBoxCategories (DonationBoxCategoryId, DonationBoxCateogryName) VALUES (1, 'Disaster')");
            Sql("INSERT INTO DonationBoxCategories (DonationBoxCategoryId, DonationBoxCateogryName) VALUES (2, 'Appliances')");
            Sql("INSERT INTO DonationBoxCategories (DonationBoxCategoryId, DonationBoxCateogryName) VALUES (3, 'Books')");
            Sql("INSERT INTO DonationBoxCategories (DonationBoxCategoryId, DonationBoxCateogryName) VALUES (4, 'Clothes')");
            Sql("INSERT INTO DonationBoxCategories (DonationBoxCategoryId, DonationBoxCateogryName) VALUES (5, 'Education')");
            Sql("INSERT INTO DonationBoxCategories (DonationBoxCategoryId, DonationBoxCateogryName) VALUES (6, 'Entertainment')");
            Sql("INSERT INTO DonationBoxCategories (DonationBoxCategoryId, DonationBoxCateogryName) VALUES (7, 'Furniture')");
            Sql("INSERT INTO DonationBoxCategories (DonationBoxCategoryId, DonationBoxCateogryName) VALUES (8, 'Technology')");
            Sql("INSERT INTO DonationBoxCategories (DonationBoxCategoryId, DonationBoxCateogryName) VALUES (9, 'Sports')");
            Sql("SET IDENTITY_INSERT DonationBoxCategories OFF");
        }
        
        public override void Down()
        {
        }
    }
}
