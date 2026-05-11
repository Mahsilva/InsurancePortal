using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseInsurance.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoToClaim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.AlterColumn<DateTime>(
        name: "StartDate",
        table: "Policies",
        type: "timestamp without time zone",
        nullable: false,
        oldClrType: typeof(DateTime),
        oldType: "timestamp with time zone");

    migrationBuilder.AlterColumn<DateTime>(
        name: "EndDate",
        table: "Policies",
        type: "timestamp without time zone",
        nullable: false,
        oldClrType: typeof(DateTime),
        oldType: "timestamp with time zone");

    migrationBuilder.AlterColumn<DateTime>(
        name: "Date",
        table: "Payments",
        type: "timestamp without time zone",
        nullable: false,
        oldClrType: typeof(DateTime),
        oldType: "timestamp with time zone");

    migrationBuilder.AlterColumn<DateTime>(
        name: "Date",
        table: "Claims",
        type: "timestamp without time zone",
        nullable: false,
        oldClrType: typeof(DateTime),
        oldType: "timestamp with time zone");

    migrationBuilder.AddColumn<string>(
        name: "PhotoPath",
        table: "Claims",
        type: "text",
        nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropColumn(
        name: "PhotoPath",
        table: "Claims");

    migrationBuilder.AlterColumn<DateTime>(
        name: "StartDate",
        table: "Policies",
        type: "timestamp with time zone",
        nullable: false,
        oldClrType: typeof(DateTime),
        oldType: "timestamp without time zone");

    migrationBuilder.AlterColumn<DateTime>(
        name: "EndDate",
        table: "Policies",
        type: "timestamp with time zone",
        nullable: false,
        oldClrType: typeof(DateTime),
        oldType: "timestamp without time zone");

    migrationBuilder.AlterColumn<DateTime>(
        name: "Date",
        table: "Payments",
        type: "timestamp with time zone",
        nullable: false,
        oldClrType: typeof(DateTime),
        oldType: "timestamp without time zone");

    migrationBuilder.AlterColumn<DateTime>(
        name: "Date",
        table: "Claims",
        type: "timestamp with time zone",
        nullable: false,
        oldClrType: typeof(DateTime),
        oldType: "timestamp without time zone");
        }
    }
}
