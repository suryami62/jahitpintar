using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jahitpintar.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameWhatsAppToPhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Identity_WhatsApp",
                table: "Customers",
                newName: "Identity_PhoneNumber");

            migrationBuilder.AddColumn<List<string>>(
                name: "Identity_SocialMediaPlatforms",
                table: "Customers",
                type: "text[]",
                nullable: false,
                defaultValueSql: "'{}'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identity_SocialMediaPlatforms",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Identity_PhoneNumber",
                table: "Customers",
                newName: "Identity_WhatsApp");
        }
    }
}
