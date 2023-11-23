using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enfonsalaflota.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class MatchUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GanadorId",
                schema: "pcfapi",
                table: "Match",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerTurnId",
                schema: "pcfapi",
                table: "Match",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VidasPlayer1",
                schema: "pcfapi",
                table: "Match",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VidasPlayer2",
                schema: "pcfapi",
                table: "Match",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Match_GanadorId",
                schema: "pcfapi",
                table: "Match",
                column: "GanadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_PlayerTurnId",
                schema: "pcfapi",
                table: "Match",
                column: "PlayerTurnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_User_GanadorId",
                schema: "pcfapi",
                table: "Match",
                column: "GanadorId",
                principalSchema: "pcfapi",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_User_PlayerTurnId",
                schema: "pcfapi",
                table: "Match",
                column: "PlayerTurnId",
                principalSchema: "pcfapi",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_User_GanadorId",
                schema: "pcfapi",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_User_PlayerTurnId",
                schema: "pcfapi",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_GanadorId",
                schema: "pcfapi",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_PlayerTurnId",
                schema: "pcfapi",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "GanadorId",
                schema: "pcfapi",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "PlayerTurnId",
                schema: "pcfapi",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "VidasPlayer1",
                schema: "pcfapi",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "VidasPlayer2",
                schema: "pcfapi",
                table: "Match");
        }
    }
}
