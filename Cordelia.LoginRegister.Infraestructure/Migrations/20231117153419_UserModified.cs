using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cordelia.LoginRegister.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class UserModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserLanguage_UserLanguageId",
                schema: "public",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserType_UserTypeId",
                schema: "public",
                table: "User");

            migrationBuilder.DropTable(
                name: "UserLanguage",
                schema: "public");

            migrationBuilder.DropTable(
                name: "UserType",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_User_UserLanguageId",
                schema: "public",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserTypeId",
                schema: "public",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DarkMode",
                schema: "public",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserLanguageId",
                schema: "public",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserLastName",
                schema: "public",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserNickname",
                schema: "public",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserTypeId",
                schema: "public",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserEmail",
                schema: "public",
                table: "User",
                column: "UserEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserName",
                schema: "public",
                table: "User",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_UserEmail",
                schema: "public",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserName",
                schema: "public",
                table: "User");

            migrationBuilder.AddColumn<bool>(
                name: "DarkMode",
                schema: "public",
                table: "User",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserLanguageId",
                schema: "public",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserLastName",
                schema: "public",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserNickname",
                schema: "public",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserTypeId",
                schema: "public",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserLanguage",
                schema: "public",
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
                schema: "public",
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

            migrationBuilder.CreateIndex(
                name: "IX_User_UserLanguageId",
                schema: "public",
                table: "User",
                column: "UserLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeId",
                schema: "public",
                table: "User",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserLanguage_UserLanguageId",
                schema: "public",
                table: "User",
                column: "UserLanguageId",
                principalSchema: "public",
                principalTable: "UserLanguage",
                principalColumn: "UserLanguageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserType_UserTypeId",
                schema: "public",
                table: "User",
                column: "UserTypeId",
                principalSchema: "public",
                principalTable: "UserType",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
