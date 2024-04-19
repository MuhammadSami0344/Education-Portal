using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalSystem.Migrations
{
    /// <inheritdoc />
    public partial class createEnrollstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EnrollStatus",
                table: "TblEnrolledUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnrollStatus",
                table: "TblEnrolledUsers");
        }
    }
}
