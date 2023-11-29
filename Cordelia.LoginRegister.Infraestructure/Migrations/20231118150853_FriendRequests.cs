using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cordelia.LoginRegister.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class FriendRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FriendRequest",
                schema: "public",
                columns: table => new
                {
                    FriendRequestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FriendRequestSenderId = table.Column<int>(type: "integer", nullable: false),
                    FriendRequestReceiverId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequest", x => x.FriendRequestId);
                    table.ForeignKey(
                        name: "FK_FriendRequest_User_FriendRequestReceiverId",
                        column: x => x.FriendRequestReceiverId,
                        principalSchema: "public",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FriendRequest_User_FriendRequestSenderId",
                        column: x => x.FriendRequestSenderId,
                        principalSchema: "public",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequest_FriendRequestReceiverId",
                schema: "public",
                table: "FriendRequest",
                column: "FriendRequestReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequest_FriendRequestSenderId",
                schema: "public",
                table: "FriendRequest",
                column: "FriendRequestSenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendRequest",
                schema: "public");
        }
    }
}
