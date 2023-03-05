using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransferMarket.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixScoredGoalTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "ScoredGoals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "ScoredGoals");
        }
    }
}
