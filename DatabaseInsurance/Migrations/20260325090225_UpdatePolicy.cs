using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseInsurance.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePolicy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarColor",
                table: "Policies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CarUsage",
                table: "Policies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CarYear",
                table: "Policies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DriverAge",
                table: "Policies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DrivingExperience",
                table: "Policies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KmPerYear",
                table: "Policies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PlanType",
                table: "Policies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarColor",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "CarUsage",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "CarYear",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "DriverAge",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "DrivingExperience",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "KmPerYear",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "PlanType",
                table: "Policies");
        }
    }
}
