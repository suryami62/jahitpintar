using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jahitpintar.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUpperBodyMeasurements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Measurements_Upper_ArmCircumference",
                table: "Customers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Measurements_Upper_BackWidth",
                table: "Customers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Measurements_Upper_FrontWidth",
                table: "Customers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Measurements_Upper_HipCircumference",
                table: "Customers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Measurements_Upper_HipHeight",
                table: "Customers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Measurements_Upper_NeckCircumference",
                table: "Customers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Measurements_Upper_WaistCircumference",
                table: "Customers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Measurements_Upper_WristCircumference",
                table: "Customers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Measurements_Upper_ArmCircumference",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Measurements_Upper_BackWidth",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Measurements_Upper_FrontWidth",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Measurements_Upper_HipCircumference",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Measurements_Upper_HipHeight",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Measurements_Upper_NeckCircumference",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Measurements_Upper_WaistCircumference",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Measurements_Upper_WristCircumference",
                table: "Customers");
        }
    }
}
