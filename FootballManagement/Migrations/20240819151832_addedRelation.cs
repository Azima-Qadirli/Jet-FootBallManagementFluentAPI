using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballManagement.Migrations
{
    /// <inheritdoc />
    public partial class addedRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Games_GuestTeamCode",
                table: "Games",
                column: "GuestTeamCode");

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeTeamCode",
                table: "Games",
                column: "HomeTeamCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_GuestTeamCode",
                table: "Games",
                column: "GuestTeamCode",
                principalTable: "Teams",
                principalColumn: "TeamCode",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_HomeTeamCode",
                table: "Games",
                column: "HomeTeamCode",
                principalTable: "Teams",
                principalColumn: "TeamCode",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_GuestTeamCode",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_HomeTeamCode",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_GuestTeamCode",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_HomeTeamCode",
                table: "Games");
        }
    }
}
