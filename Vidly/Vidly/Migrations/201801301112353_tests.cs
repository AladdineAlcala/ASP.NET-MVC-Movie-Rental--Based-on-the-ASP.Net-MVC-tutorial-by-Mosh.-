namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tests : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[Customers] ([Name], [IsSubscribedTONewsLetter], [MembershipTypeId], [DateofBirth]) VALUES ('John Smithss', 0, 1,'1900-01-01 00:00:00')");
        }
        
        public override void Down()
        {
        }
    }
}
