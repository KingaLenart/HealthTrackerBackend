using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthTrackerApp.Core.SQL.Migrations
{
    /// <inheritdoc />
    public partial class RemovePeriodTimeSpan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenstruationLength",
                table: "PeriodsCycle");

            migrationBuilder.DropColumn(
                name: "PeriodCycleLenght",
                table: "PeriodsCycle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "MenstruationLength",
                table: "PeriodsCycle",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "PeriodCycleLenght",
                table: "PeriodsCycle",
                type: "time",
                nullable: true);
        }
    }
}
