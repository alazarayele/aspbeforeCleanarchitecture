using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asp.Migrations
{
    /// <inheritdoc />
    public partial class yourMigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "person",
                table: "Careers",
                newName: "Careerperson");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Careerperson",
                table: "Careers",
                newName: "person");
        }
    }
}
