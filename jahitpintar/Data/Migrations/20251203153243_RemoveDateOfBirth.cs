using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jahitpintar.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDateOfBirth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identity_DateOfBirth",
                table: "Customers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "Identity_DateOfBirth",
                table: "Customers",
                type: "date",
                nullable: true);
        }
    }
}
