using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasswordLess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "Code");

            migrationBuilder.AddColumn<DateTime>(
                name: "PasswordCode_ExpirationDate",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordCode_ExpirationDate",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Users",
                newName: "Password");
        }
    }
}
