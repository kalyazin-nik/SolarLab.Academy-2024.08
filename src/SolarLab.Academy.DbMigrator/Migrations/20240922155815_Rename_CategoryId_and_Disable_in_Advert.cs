using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarLab.Academy.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class Rename_CategoryId_and_Disable_in_Advert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Categories_CategoryID",
                table: "Adverts");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Adverts",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "IsDisabled",
                table: "Adverts",
                newName: "Disabled");

            migrationBuilder.RenameIndex(
                name: "IX_Adverts_CategoryID",
                table: "Adverts",
                newName: "IX_Adverts_CategoryId");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Adverts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Categories_CategoryId",
                table: "Adverts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Categories_CategoryId",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Adverts");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Adverts",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "Disabled",
                table: "Adverts",
                newName: "IsDisabled");

            migrationBuilder.RenameIndex(
                name: "IX_Adverts_CategoryId",
                table: "Adverts",
                newName: "IX_Adverts_CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Categories_CategoryID",
                table: "Adverts",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
