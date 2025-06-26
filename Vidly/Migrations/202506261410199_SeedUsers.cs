namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'92a0ddda-2251-48b4-96f3-6fd3332cb6be', N'admin@vidly.com', 0, N'AMQ3K/wR3jjLQRrp0gkhi0NYsYe/sUtMwiBQhoq6A03uonOrqq/2ayJhkLJ9kQ4XHw==', N'fb78b4d1-4168-47d0-ae8a-09e6a4ba5065', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c4f1f2a7-5e11-4e81-a6b3-88a7dde0b5dc', N'guest@vidly.com', 0, N'AHWlLlPGs5jPF3mj7Eeie/zCIOvQ9qLCNBjqXFDHGs2KFrvOJnuBzjATk1WiDdgeSw==', N'26ff7702-eb80-407f-9fe2-4c83e5139ecf', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7112ad08-d0f4-4e5d-9efe-6b5049f2bcfd', N'CanManageMovie')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'92a0ddda-2251-48b4-96f3-6fd3332cb6be', N'7112ad08-d0f4-4e5d-9efe-6b5049f2bcfd')

                ");
        }

        public override void Down()
        {
        }
    }
}
