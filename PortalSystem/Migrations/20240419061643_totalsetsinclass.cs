using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalSystem.Migrations
{
    /// <inheritdoc />
    public partial class totalsetsinclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaxSize",
                table: "TblClasses",
                newName: "TotalSets");

            migrationBuilder.AddColumn<int>(
                name: "RemainingSets",
                table: "TblClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemainingSets",
                table: "TblClasses");

            migrationBuilder.RenameColumn(
                name: "TotalSets",
                table: "TblClasses",
                newName: "MaxSize");
        }
    }
}
