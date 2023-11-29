using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cordelia.LoginRegister.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCampoSecretKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pcfapi");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "public",
                newName: "User",
                newSchema: "pcfapi");

            migrationBuilder.RenameTable(
                name: "Message",
                schema: "public",
                newName: "Message",
                newSchema: "pcfapi");

            migrationBuilder.RenameTable(
                name: "FriendRequest",
                schema: "public",
                newName: "FriendRequest",
                newSchema: "pcfapi");

            migrationBuilder.RenameColumn(
                name: "UserPassword",
                schema: "pcfapi",
                table: "User",
                newName: "SecretKet");

            migrationBuilder.AddColumn<bool>(
                name: "DarkMode",
                schema: "pcfapi",
                table: "User",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                schema: "pcfapi",
                table: "User",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                schema: "pcfapi",
                table: "User",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserLanguageId",
                schema: "pcfapi",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserTypeId",
                schema: "pcfapi",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DarkMode",
                schema: "pcfapi",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "pcfapi",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                schema: "pcfapi",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserLanguageId",
                schema: "pcfapi",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserTypeId",
                schema: "pcfapi",
                table: "User");

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "pcfapi",
                newName: "User",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Message",
                schema: "pcfapi",
                newName: "Message",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "FriendRequest",
                schema: "pcfapi",
                newName: "FriendRequest",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "SecretKet",
                schema: "public",
                table: "User",
                newName: "UserPassword");
        }
    }
}
