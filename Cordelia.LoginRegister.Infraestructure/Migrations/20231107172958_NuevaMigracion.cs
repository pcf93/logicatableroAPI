using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cordelia.LoginRegister.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class NuevaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "UserType",
                schema: "pcfapi",
                newName: "UserType",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "UserLanguage",
                schema: "pcfapi",
                newName: "UserLanguage",
                newSchema: "public");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pcfapi");

            migrationBuilder.RenameTable(
                name: "UserType",
                schema: "public",
                newName: "UserType",
                newSchema: "pcfapi");

            migrationBuilder.RenameTable(
                name: "UserLanguage",
                schema: "public",
                newName: "UserLanguage",
                newSchema: "pcfapi");

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
        }
    }
}
