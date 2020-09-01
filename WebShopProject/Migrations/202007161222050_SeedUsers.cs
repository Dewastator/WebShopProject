namespace WebShopProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c67665af-3aaf-4381-90de-bfcb233e96b8', N'admin@gmail.com', 0, N'AMrUk830is2VldxpuHKzsHlmfoBzzcf7cqiHNbcJx45dbfiHs+PgWV1V4kNIOX58Hg==', " +
                "N'77211086-b62a-49e2-8caf-31f72a4ce10f', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')");
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bfcbc051-a5e8-452d-9254-8438a1dbb09d', N'guest@gmail.com', 0, N'AHThFRH0vA2+O/+o2DC7O1UOwl7MAQlForM8X5Dank6CXmN9EVTDnyraHco/TfczfA=='," +
                " N'4540d55e-377a-49f1-bcc8-4e9acc6fac99', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6cddc203-519b-4bba-86fa-8595ebbc3a51', N'CanManageProducts')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c67665af-3aaf-4381-90de-bfcb233e96b8', N'6cddc203-519b-4bba-86fa-8595ebbc3a51')");
        }
        
        public override void Down()
        {
        }
    }
}
