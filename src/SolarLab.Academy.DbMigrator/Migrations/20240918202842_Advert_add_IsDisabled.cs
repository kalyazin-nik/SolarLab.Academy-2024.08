using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarLab.Academy.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class Advert_add_IsDisabled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Adverts",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Adverts");
        }
    }
}
