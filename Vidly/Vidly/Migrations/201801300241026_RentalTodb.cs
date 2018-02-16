namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalTodb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        customer_rental_Id = c.Int(nullable: false),
                        Movie_rental_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.customer_rental_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_rental_Id, cascadeDelete: true)
                .Index(t => t.customer_rental_Id)
                .Index(t => t.Movie_rental_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Movie_rental_Id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "customer_rental_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Movie_rental_Id" });
            DropIndex("dbo.Rentals", new[] { "customer_rental_Id" });
            DropTable("dbo.Rentals");
        }
    }
}
