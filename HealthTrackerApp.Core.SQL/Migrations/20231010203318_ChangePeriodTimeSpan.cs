using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthTrackerApp.Core.SQL.Migrations
{
    /// <inheritdoc />
    public partial class ChangePeriodTimeSpan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "PeriodCycleLenght",
                table: "PeriodsCycle",
                type: "time",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "MenstruationLength",
                table: "PeriodsCycle",
                type: "time",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PeriodCycleLenght",
                table: "PeriodsCycle",
                type: "int",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<int>(
                name: "MenstruationLength",
                table: "PeriodsCycle",
                type: "int",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }
    }
}
