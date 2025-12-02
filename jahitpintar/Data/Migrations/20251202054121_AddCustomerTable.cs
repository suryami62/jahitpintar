using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jahitpintar.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Identity_Name = table.Column<string>(type: "text", nullable: false),
                    Identity_WhatsApp = table.Column<string>(type: "text", nullable: false),
                    Identity_Address = table.Column<string>(type: "text", nullable: false),
                    Identity_DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Measurements_Upper_ChestCircumference = table.Column<double>(type: "double precision", nullable: false),
                    Measurements_Upper_ShoulderWidth = table.Column<double>(type: "double precision", nullable: false),
                    Measurements_Upper_SleeveLength = table.Column<string>(type: "text", nullable: false),
                    Measurements_Upper_ArmholeCircumference = table.Column<double>(type: "double precision", nullable: false),
                    Measurements_Upper_ShirtLength = table.Column<double>(type: "double precision", nullable: false),
                    Measurements_Lower_WaistCircumference = table.Column<double>(type: "double precision", nullable: false),
                    Measurements_Lower_HipCircumference = table.Column<double>(type: "double precision", nullable: false),
                    Measurements_Lower_LegLength = table.Column<double>(type: "double precision", nullable: false),
                    Measurements_Lower_ThighCircumference = table.Column<double>(type: "double precision", nullable: false),
                    Measurements_Height = table.Column<double>(type: "double precision", nullable: false),
                    Measurements_Weight = table.Column<double>(type: "double precision", nullable: false),
                    Preferences_FittingStyle = table.Column<string>(type: "text", nullable: false),
                    Preferences_FabricFavorite = table.Column<string>(type: "text", nullable: false),
                    Preferences_OrderHistory = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
