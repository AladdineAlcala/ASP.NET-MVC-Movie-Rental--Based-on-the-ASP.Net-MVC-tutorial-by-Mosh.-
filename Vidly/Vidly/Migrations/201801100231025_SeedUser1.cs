namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c7fb7abe-eb2b-4bc3-b41f-1d531ad3ebba', N'admin@Vidly.com', 0, N'ANDRi8wmc+7SwrkLO2gxHVKDzFtc/0LWRQxNAMNYqq/G9ghjZ47cseBJ+WImXAQc1w==', N'662be62d-b712-4f58-88c1-c92f9f464165', NULL, 0, 0, NULL, 1, 0, N'admin@Vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c92c331e-ccc4-4c63-a504-ce0e33e7b44d', N'guest@guest.com', 0, N'AC+f5cg9QPKJEII6Tqhs/iLF6V1n0gxrKCLNfuxPj/Lt0xujJTo1NMZBbfKok1AkEg==', N'53c9f067-a9a8-4927-a38b-ed91c91e08c0', NULL, 0, 0, NULL, 1, 0, N'guest@guest.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f98523f8-23ec-42e7-93b6-36a99f3d2ba7', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c7fb7abe-eb2b-4bc3-b41f-1d531ad3ebba', N'f98523f8-23ec-42e7-93b6-36a99f3d2ba7')
");
        }
        
        public override void Down()
        {
        }
    }
}
