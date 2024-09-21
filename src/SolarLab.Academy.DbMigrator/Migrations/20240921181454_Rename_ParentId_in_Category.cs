using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarLab.Academy.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class Rename_ParentId_in_Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentID",
                table: "Categories",
                newName: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Categories",
                newName: "ParentID");
        }
    }
}
