using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballManagement.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumberOfWins = table.Column<int>(type: "int", nullable: false),
                    NumberOfEquality = table.Column<int>(type: "int", nullable: false),
                    NumberOfDefeat = table.Column<int>(type: "int", nullable: false),
                    NumberOfGoalsScored = table.Column<int>(type: "int", nullable: false),
                    NumberOfGoalsConceded = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamCode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
