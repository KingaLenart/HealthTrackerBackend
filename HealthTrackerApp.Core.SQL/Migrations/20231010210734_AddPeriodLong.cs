using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthTrackerApp.Core.SQL.Migrations
{
    /// <inheritdoc />
    public partial class AddPeriodLong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MenstruationLength",
                table: "PeriodsCycle",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PeriodCycleLenght",
                table: "PeriodsCycle",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenstruationLength",
                table: "PeriodsCycle");

            migrationBuilder.DropColumn(
                name: "PeriodCycleLenght",
                table: "PeriodsCycle");
        }
    }
}
