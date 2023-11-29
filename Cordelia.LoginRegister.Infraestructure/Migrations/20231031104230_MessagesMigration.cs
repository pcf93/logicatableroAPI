using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cordelia.LoginRegister.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class MessagesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message",
                schema: "pcfapi");
        }
    }
}
