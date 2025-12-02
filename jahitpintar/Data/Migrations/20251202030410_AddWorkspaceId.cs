using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jahitpintar.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkspaceId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkspaceId",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkspaceId",
                table: "AspNetUsers");
        }
    }
}
