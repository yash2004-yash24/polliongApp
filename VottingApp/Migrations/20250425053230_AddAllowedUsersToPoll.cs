using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VottingApp.Migrations
{
    /// <inheritdoc />
    public partial class AddAllowedUsersToPoll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AllowedUserIds",
                table: "Polls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowedUserIds",
                table: "Polls");
        }
    }
}
