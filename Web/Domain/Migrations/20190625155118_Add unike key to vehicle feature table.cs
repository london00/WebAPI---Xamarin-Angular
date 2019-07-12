using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyDotNetCoreAngular.Migrations
{
    public partial class Addunikekeytovehiclefeaturetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VehicleFeatures_FeatureId",
                table: "VehicleFeatures");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleFeatures_FeatureId_VehicleId",
                table: "VehicleFeatures",
                columns: new[] { "FeatureId", "VehicleId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VehicleFeatures_FeatureId_VehicleId",
                table: "VehicleFeatures");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleFeatures_FeatureId",
                table: "VehicleFeatures",
                column: "FeatureId");
        }
    }
}
