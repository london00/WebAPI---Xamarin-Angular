using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyDotNetCoreAngular.Migrations
{
    public partial class SeedModelsandMakestables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO [Makes] ([Name]) VALUES 
                ('Ford'),
                ('Nissan'),
                ('Volkswagen');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO [Models]([Name], [MakeId]) VALUES
                ('Fiesta', (SELECT TOP(1) Id FROM [Makes] WHERE [Name] = 'Ford')),
                ('Focus', (SELECT TOP(1) Id FROM [Makes] WHERE [Name] = 'Ford')),
                ('Fusion', (SELECT TOP(1) Id FROM [Makes] WHERE [Name] = 'Ford'));
            ");

            migrationBuilder.Sql(@"
                INSERT INTO [Models]([Name], [MakeId]) VALUES
                ('Altima', (SELECT TOP(1) Id FROM [Makes] WHERE [Name] = 'Nissan')),
                ('Versa', (SELECT TOP(1) Id FROM [Makes] WHERE [Name] = 'Nissan')),
                ('Sentra', (SELECT TOP(1) Id FROM [Makes] WHERE [Name] = 'Nissan'));
            ");

            migrationBuilder.Sql(@"
                INSERT INTO [Models]([Name], [MakeId]) VALUES
                ('Bora', (SELECT TOP(1) Id FROM [Makes] WHERE [Name] = 'Volkswagen')),
                ('Jetta', (SELECT TOP(1) Id FROM [Makes] WHERE [Name] = 'Volkswagen')),
                ('Polo', (SELECT TOP(1) Id FROM [Makes] WHERE [Name] = 'Volkswagen'));
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE [Makes];");
            migrationBuilder.Sql("TRUNCATE TABLE [Models];");
        }
    }
}
