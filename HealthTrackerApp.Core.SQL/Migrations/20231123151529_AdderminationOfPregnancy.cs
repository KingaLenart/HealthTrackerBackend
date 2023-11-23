using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthTrackerApp.Core.SQL.Migrations
{
    /// <inheritdoc />
    public partial class AdderminationOfPregnancy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Abortion",
                table: "Pregnancies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Miscarriage",
                table: "Pregnancies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TerminationOfPregnancy",
                table: "Pregnancies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TerminationOfPregnancyDate",
                table: "Pregnancies",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abortion",
                table: "Pregnancies");

            migrationBuilder.DropColumn(
                name: "Miscarriage",
                table: "Pregnancies");

            migrationBuilder.DropColumn(
                name: "TerminationOfPregnancy",
                table: "Pregnancies");

            migrationBuilder.DropColumn(
                name: "TerminationOfPregnancyDate",
                table: "Pregnancies");
        }
    }
}
