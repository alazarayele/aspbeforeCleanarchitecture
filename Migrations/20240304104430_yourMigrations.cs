using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asp.Migrations
{
    /// <inheritdoc />
    public partial class yourMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "person",
                table: "CommunicationSources",
                newName: "CommunicationSourceperson");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommunicationSourceperson",
                table: "CommunicationSources",
                newName: "person");
        }
    }
}
