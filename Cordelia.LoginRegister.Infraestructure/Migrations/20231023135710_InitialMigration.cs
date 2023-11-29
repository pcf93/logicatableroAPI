using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cordelia.LoginRegister.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pcfapi");

            migrationBuilder.CreateTable(
                name: "UserLanguage",
                schema: "pcfapi",
                columns: table => new
                {
                    UserLanguageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserLanguageName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguage", x => x.UserLanguageId);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                schema: "pcfapi",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserTypeName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "pcfapi",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserPassword = table.Column<string>(type: "text", nullable: true),
                    UserNickname = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    UserLastName = table.Column<string>(type: "text", nullable: true),
                    UserEmail = table.Column<string>(type: "text", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_User_UserLanguage_UserLanguageId",
                        column: x => x.UserLanguageId,
                        principalSchema: "pcfapi",
                        principalTable: "UserLanguage",
                        principalColumn: "UserLanguageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserType_UserTypeId",
                        column: x => x.UserTypeId,
                        principalSchema: "pcfapi",
                        principalTable: "UserType",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_UserLanguageId",
                schema: "pcfapi",
                table: "User",
                column: "UserLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeId",
                schema: "pcfapi",
                table: "User",
                column: "UserTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User",
                schema: "pcfapi");

            migrationBuilder.DropTable(
                name: "UserLanguage",
                schema: "pcfapi");

            migrationBuilder.DropTable(
                name: "UserType",
                schema: "pcfapi");
        }
    }
}
