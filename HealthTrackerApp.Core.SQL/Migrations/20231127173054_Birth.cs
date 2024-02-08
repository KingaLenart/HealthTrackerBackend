using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthTrackerApp.Core.SQL.Migrations
{
    /// <inheritdoc />
    public partial class Birth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Pregnancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsPregnancyFinish",
                table: "Pregnancies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Pregnancies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Pregnancies");

            migrationBuilder.DropColumn(
                name: "IsPregnancyFinish",
                table: "Pregnancies");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Pregnancies");
        }
    }
}
