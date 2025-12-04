using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jahitpintar.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLowerBodyMeasurements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Measurements_Lower_AnkleCircumference",
                table: "Customers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Measurements_Lower_CrotchCircumference",
                table: "Customers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Measurements_Lower_KneeCircumference",
                table: "Customers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Measurements_Lower_PantsLength",
                table: "Customers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Measurements_Lower_SeatedHeight",
                table: "Customers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Measurements_Lower_AnkleCircumference",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Measurements_Lower_CrotchCircumference",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Measurements_Lower_KneeCircumference",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Measurements_Lower_PantsLength",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Measurements_Lower_SeatedHeight",
                table: "Customers");
        }
    }
}
