using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Enfonsalaflota.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class MatchMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pcfapi");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "pcfapi",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserEmail = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    UserPhone = table.Column<string>(type: "text", nullable: true),
                    UserBirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCity = table.Column<string>(type: "text", nullable: true),
                    DarkMode = table.Column<bool>(type: "boolean", nullable: false),
                    UserLanguageId = table.Column<int>(type: "integer", nullable: false),
                    UserTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "FriendRequest",
                schema: "pcfapi",
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
                        principalSchema: "pcfapi",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FriendRequest_User_FriendRequestSenderId",
                        column: x => x.FriendRequestSenderId,
                        principalSchema: "pcfapi",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                schema: "pcfapi",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Player1Id = table.Column<int>(type: "integer", nullable: false),
                    Player2Id = table.Column<int>(type: "integer", nullable: false),
                    ArrayPlayer1 = table.Column<int[]>(type: "integer[]", nullable: true),
                    ArrayPlayer2 = table.Column<int[]>(type: "integer[]", nullable: true),
                    VidasPlayer1 = table.Column<int>(type: "integer", nullable: false),
                    VidasPlayer2 = table.Column<int>(type: "integer", nullable: false),
                    PlayerTurnId = table.Column<int>(type: "integer", nullable: false),
                    GanadorId = table.Column<int>(type: "integer", nullable: false),
                    MatchStatus = table.Column<int>(type: "integer", nullable: false),
                    MatchStartType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Match_User_GanadorId",
                        column: x => x.GanadorId,
                        principalSchema: "pcfapi",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Match_User_Player1Id",
                        column: x => x.Player1Id,
                        principalSchema: "pcfapi",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Match_User_Player2Id",
                        column: x => x.Player2Id,
                        principalSchema: "pcfapi",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Match_User_PlayerTurnId",
                        column: x => x.PlayerTurnId,
                        principalSchema: "pcfapi",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                schema: "pcfapi",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MessageSenderId = table.Column<int>(type: "integer", nullable: false),
                    MessageReceiverId = table.Column<int>(type: "integer", nullable: false),
                    MessageSubject = table.Column<string>(type: "text", nullable: true),
                    MessageContent = table.Column<string>(type: "text", nullable: true),
                    MessageDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Message_User_MessageReceiverId",
                        column: x => x.MessageReceiverId,
                        principalSchema: "pcfapi",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Message_User_MessageSenderId",
                        column: x => x.MessageSenderId,
                        principalSchema: "pcfapi",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchMessage",
                schema: "pcfapi",
                columns: table => new
                {
                    MatchMessageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MessageSenderId = table.Column<int>(type: "integer", nullable: false),
                    MatchId = table.Column<int>(type: "integer", nullable: false),
                    MatchMessageContent = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchMessage", x => x.MatchMessageId);
                    table.ForeignKey(
                        name: "FK_MatchMessage_Match_MatchId",
                        column: x => x.MatchId,
                        principalSchema: "pcfapi",
                        principalTable: "Match",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchMessage_User_MessageSenderId",
                        column: x => x.MessageSenderId,
                        principalSchema: "pcfapi",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequest_FriendRequestReceiverId",
                schema: "pcfapi",
                table: "FriendRequest",
                column: "FriendRequestReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequest_FriendRequestSenderId",
                schema: "pcfapi",
                table: "FriendRequest",
                column: "FriendRequestSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_GanadorId",
                schema: "pcfapi",
                table: "Match",
                column: "GanadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Player1Id",
                schema: "pcfapi",
                table: "Match",
                column: "Player1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Player2Id",
                schema: "pcfapi",
                table: "Match",
                column: "Player2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Match_PlayerTurnId",
                schema: "pcfapi",
                table: "Match",
                column: "PlayerTurnId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchMessage_MatchId",
                schema: "pcfapi",
                table: "MatchMessage",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchMessage_MessageSenderId",
                schema: "pcfapi",
                table: "MatchMessage",
                column: "MessageSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_MessageReceiverId",
                schema: "pcfapi",
                table: "Message",
                column: "MessageReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_MessageSenderId",
                schema: "pcfapi",
                table: "Message",
                column: "MessageSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserEmail",
                schema: "pcfapi",
                table: "User",
                column: "UserEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserName",
                schema: "pcfapi",
                table: "User",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendRequest",
                schema: "pcfapi");

            migrationBuilder.DropTable(
                name: "MatchMessage",
                schema: "pcfapi");

            migrationBuilder.DropTable(
                name: "Message",
                schema: "pcfapi");

            migrationBuilder.DropTable(
                name: "Match",
                schema: "pcfapi");

            migrationBuilder.DropTable(
                name: "User",
                schema: "pcfapi");
        }
    }
}
