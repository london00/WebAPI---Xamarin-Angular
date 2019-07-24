using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyDotNetCoreAngular.Migrations
{
    public partial class Addadminuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'3fb99518-8267-46ea-9791-0400941892fd', N'Admin', N'ADMIN', N'eb5a4fd8-35c7-478e-81b1-cb5df3fc092f')
                INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator]) VALUES (N'fe7e42cc-5cd9-4aa3-8d99-a6bf411a1078', N'Admin', N'ADMIN', N'geiser.aragon@ksquareinc.com', N'GEISER.ARAGON@KSQUAREINC.COM', 0, N'AQAAAAEAACcQAAAAEIH/rkdnw7TWWK83GLRzcWV+o1BbmtSL4P/2v0NJtRCqE0h75pl+WAj0Ms5amq0/Gw==', N'7CVDV4FGMEY4B6NKO3F3PZ7T33ZPNFRE', N'ee594490-9a84-4cfb-888f-c7ed8d9aa8f9', NULL, 0, 0, NULL, 1, 0, N'User')
                INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fe7e42cc-5cd9-4aa3-8d99-a6bf411a1078', N'3fb99518-8267-46ea-9791-0400941892fd')
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE  [dbo].[AspNetUserRoles]
                DELETE [dbo].[AspNetRoles]
                DELETE  [dbo].[AspNetUsers]
            ");
        }
    }
}
